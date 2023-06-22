using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.CreateUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.RemoveUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.UpdateUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllActiveUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllFilterUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetBasketUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetUnit;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos.ProductOptions;
using QuickSalesApp.Domain.Dtos.SalesBasketDtoClient;
using QuickSalesApp.Domain.Repositories.Company.UnitRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Utilities;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class UnitService : IUnitService
{

    private readonly IUnitCommandRepository _commandRepository;
    private readonly IUnitQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
    private readonly IMapper _mapper;
    private CompanyDbContext _context;
    public UnitService(IMapper mapper, ICompanyDbUnitOfWork companyDbUnitOfWork, IContextService contextService, IUnitQueryRepository queryRepository, IUnitCommandRepository commandRepository)
    {
        _mapper = mapper;
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _contextService = contextService;
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
    }

    public async Task<Unit> ChangeState(Unit unit, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(unit);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return unit;
    }

    public async Task CreateAsync(CreateUnitCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        Unit unit = _mapper.Map<Unit>(request);

        await _commandRepository.AddAsync(unit, cancellationToken);
        await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<Unit>> GetAll(GetAllUnitQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsDelete == false).OrderBy(p => p.Id).ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public async Task<PaginationResult<Unit>> GetAllActive(GetAllActiveUnitQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true && p.IsDelete == false).OrderBy(p => p.Id).ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public async Task<PaginationResult<Unit>> GetAllFilter(GetAllFilterUnitQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        if (request.Expression == null)
        {
            var queryGetAll = _queryRepository.GetAll().Where(p => p.IsDelete == false).OrderBy(p => p.Id);
            var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAll;
        }
        var expression = ExpressionParser.ParseExpression<Unit>(request.Expression);
        var query = _queryRepository.GetAll().Where(p => p.IsDelete == false).Where(expression);
        var result = await query.ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public async  Task<IList<Unit>> GetBasketUnit(GetBasketUnitQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true && p.IsDelete == false).OrderBy(p => p.Id).ToListAsync();

       
        return result;
    }

    public async Task<Unit> GetByIdAsync(int Id, string CompanyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(CompanyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetById(Id);
    }

    public async Task<ProductOptionsGetByIdDto> GetByIdForCheck(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var res = _queryRepository.GetAll()
        .Where(p => p.Id == id)
        .Include(p => p.ProductUnits)
        .Select(p => new ProductOptionsGetByIdDto(p.ProductUnits.FirstOrDefault().IsActive == true ? p.ProductUnits.FirstOrDefault().Price.ToString() : null))
        .FirstOrDefault();
        return res;
    }

    public async Task<Unit> GetByNameAsync(string Name, string CompanyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(CompanyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetFirstByExpression(p => p.Name == Name && p.IsActive == true, default);
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }

    public int GetCountbyFilter(string companyId, string expression)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        if (expression == null)
            return _queryRepository.GetAll().Count();

        var newExpression = ExpressionParser.ParseExpression<Unit>(expression);
        return _queryRepository.GetAll().Where(p => p.IsDelete == false).Where(newExpression).OrderBy(p => p.Id).Count();
    }

    public async Task<GetUnitQueryResponse> GetUnit(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var unit = await _queryRepository.GetWhere(x => x.Id == id).FirstOrDefaultAsync();
        var response = _mapper.Map<GetUnitQueryResponse>(unit);
        return response;
    }

    public async Task<Unit> RemoveByIdHard(RemoveUnitCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        Unit unit = await _queryRepository.GetById(request.id);
        await _commandRepository.RemoveById(request.id);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return unit;
    }

    public async Task<Unit> RemoveByIdSoft(string companyId, Unit unit)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(unit);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return unit;
    }

    public async Task<Unit> UpdateAsync(UpdateUnitCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        Unit unit = _mapper.Map<Unit>(request);
        _commandRepository.Update(unit);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return unit;
    }
}
