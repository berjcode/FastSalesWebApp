using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.CreatePersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.RemovePersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.UpdatePersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetById;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.PersonalRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class PersonalService : IPersonalService
{

    private readonly IPersonalCommandRepository _commandRepository;
    private readonly IPersonalQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    private readonly ICompanyDbUnitOfWork _unitOfWork;

    public PersonalService(ICompanyDbUnitOfWork unitOfWork, IMapper mapper, IContextService contextService, IPersonalQueryRepository queryRepository, IPersonalCommandRepository commandRepository)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _contextService = contextService;
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
    }

    public async Task CreateAsync(CreatePersonalCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Personal personal = _mapper.Map<Personal>(request);
        personal.BeginDate = DateTime.Now;

        await _commandRepository.AddAsync(personal, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<Personal> RemoveByIdHard(RemovePersonalCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Personal personal = await _queryRepository.GetById(request.id);
        _commandRepository.Remove(personal);
        await _unitOfWork.SaveChangesAsync(default);
        return personal;
    }

    public async Task<Personal> ChangeState(Personal personal, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(personal);
        await _unitOfWork.SaveChangesAsync();
        return personal;
    }

    public async Task<PaginationResult<Personal>> GetAllActive(string companyId, int pageNumber, int pageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true).OrderByDescending(p => p.CreatedDate).Include(p => p.Department).ToPagedListAsync(pageNumber, pageSize);
        return result;
    }

    public async Task<Personal> GetByIdAsync(int personalId, string CompanyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetById(personalId);
    }
    public async Task<Personal> UpdateAsync(UpdatePersonalCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Personal personal = _mapper.Map<Personal>(request);
        _commandRepository.Update(personal);
        await _unitOfWork.SaveChangesAsync();
        return personal;
    }

    public async Task<Personal> GetByEmailAsync(string email, string CompanyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        return await _queryRepository.GetFirstByExpression(p => p.Email == email);
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }

    public async Task<Personal> RemoveByIdSoft(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        Personal personal = await _queryRepository.GetById(id);
        personal.IsActive = false;
        personal.IsDelete = true;
        _commandRepository.Update(personal);
        await _unitOfWork.SaveChangesAsync();
        return personal;
    }

    public async Task<GetByIdPersonalQueryResponse> GetPersonal(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var productType = await _queryRepository.GetWhere(x => x.Id == id).Include(p => p.Department).FirstOrDefaultAsync();
        var response = _mapper.Map<GetByIdPersonalQueryResponse>(productType);
        return response;
    }
}
