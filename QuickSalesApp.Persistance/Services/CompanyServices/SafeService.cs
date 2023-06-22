using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.CreateSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.RemoveSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.UpdateSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetAllSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetByIdSafe;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.SafeRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class SafeService : ISafeService
{
    private readonly ISafeCommandRepository _commandRepository;
    private readonly IContextService _contextService;
    private readonly ISafeQueryRepository _queryRepository;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
    private readonly IMapper _mapper;

    public SafeService(IMapper mapper, ICompanyDbUnitOfWork companyDbUnitOfWork, ISafeQueryRepository queryRepository, IContextService contextService, ISafeCommandRepository commandRepository)
    {
        _mapper = mapper;
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _queryRepository = queryRepository;
        _contextService = contextService;
        _commandRepository = commandRepository;
    }

    private CompanyDbContext _context;


    public async Task<Safe> ChangeState(Safe safe, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(safe);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return safe;
    }

    public async Task CreateAsync(CreateSafeCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        Safe safe = _mapper.Map<Safe>(request);
        safe.Code = await generateCode(request.Code.ToUpper(), request.CompanyId);
        await _commandRepository.AddAsync(safe, cancellationToken);
        await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<Safe>> GetAllActive(GetAllSafeQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true).OrderByDescending(p => p.CreatedDate).Include(p => p.Currency).ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public async Task<Safe> GetByIdAsync(int Id, string CompanyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(CompanyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetById(Id);
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }

    public async Task<GetByIdSafeQueryResponse> GetSafe(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var safe = await _queryRepository.GetWhere(x => x.Id == id).Include(p => p.Currency).FirstOrDefaultAsync();
        var response = _mapper.Map<GetByIdSafeQueryResponse>(safe);
        return response;
    }

    public async Task<Safe> RemoveByIdHard(RemoveSafeCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        Safe safe = await _queryRepository.GetById(request.id);
        await _commandRepository.RemoveById(request.id);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return safe;
    }

    public async Task<Safe> RemoveByIdSoft(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        Safe safe = await _queryRepository.GetById(id);
        safe.IsActive = false;
        safe.IsDelete = true;
        _commandRepository.Update(safe);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return safe;
    }

    public async Task<Safe> UpdateAsync(UpdateSafeCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        Safe safe = _mapper.Map<Safe>(request);
        _commandRepository.Update(safe);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return safe;
    }

    private async Task<string> generateCode(string code, string companyId)
    {
        var stockNumber = await getByCode(code, companyId) + 1;
        return $"{code}{stockNumber.ToString("D3")}";
    }

    private async Task<int> getByCode(string code, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var data = _queryRepository.GetWhere(p => p.Code.Substring(0, code.Length) == code);
        return data.Count();
    }

    public async Task<Safe> GetByNameAsync(string Name, string CompanyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(CompanyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetFirstByExpression(p => p.Name == Name, default);
    }
}
