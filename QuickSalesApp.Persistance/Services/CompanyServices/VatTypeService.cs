using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.CreateVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.RemoveVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.UpdateVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllActiveVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllFilterVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetVatType;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos.ProductOptions;
using QuickSalesApp.Domain.Repositories.Company.VatTypeRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Utilities;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class VatTypeService : IVatTypeService
{
    private readonly IVatTypeCommandRepository _commandRepository;
    private readonly IVatTypeQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
    private readonly IMapper _mapper;

    public VatTypeService(IMapper mapper, ICompanyDbUnitOfWork companyDbUnitOfWork, IContextService contextService, IVatTypeQueryRepository queryRepository, IVatTypeCommandRepository commandRepository)
    {
        _mapper = mapper;
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _contextService = contextService;
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
    }
    private CompanyDbContext _context;
    public async Task<VatType> ChangeState(VatType vatType, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(vatType);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return vatType;
    }

    public async Task CreateAsync(CreateVatTypeCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        VatType type = _mapper.Map<VatType>(request);

        await _commandRepository.AddAsync(type, cancellationToken);
        await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<VatType>> GetAllActive(GetAllActiveVatTypeQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true && p.IsDelete == false).OrderBy(p => p.Id).ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public async Task<PaginationResult<VatType>> GetAll(GetAllVatTypeQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsDelete == false).OrderBy(p => p.Value).ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public async Task<VatType> GetByIdAsync(int Id, string CompanyId)
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

    public async Task<GetVatTypeQueryResponse> GetVatType(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var vatType = await _queryRepository.GetWhere(x => x.Id == id).FirstOrDefaultAsync();
        var response = _mapper.Map<GetVatTypeQueryResponse>(vatType);
        return response;
    }

    public async Task<VatType> RemoveByIdHard(RemoveVatTypeCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        VatType type = await _queryRepository.GetById(request.id);
        await _commandRepository.RemoveById(request.id);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return type;
    }

    public async Task<VatType> RemoveByIdSoft(string companyId, VatType vatType)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(vatType);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return vatType;
    }

    public async Task<VatType> UpdateAsync(UpdateVatTypeCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        VatType type = _mapper.Map<VatType>(request);
        type.UpdateDate = DateTime.Now;
        _commandRepository.Update(type);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return type;
    }

    public async Task<PaginationResult<VatType>> GetAllFilter(GetAllFilterVatTypeQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        if (request.Expression == null)
        {
            var queryGetAll = _queryRepository.GetAll().Where(p => p.IsDelete == false).OrderBy(p => p.Id);
            var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAll;
        }
        var expression = ExpressionParser.ParseExpression<VatType>(request.Expression);
        var query = _queryRepository.GetAll().Where(p => p.IsDelete == false).Where(expression);
        var result = await query.ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public int GetCountbyFilter(string companyId, string expression)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        if (expression == null)
            return _queryRepository.GetAll().Count();

        var newExpression = ExpressionParser.ParseExpression<VatType>(expression);
        return _queryRepository.GetAll().Where(p => p.IsDelete == false).Where(newExpression).OrderBy(p => p.Id).Count();
    }

    public async Task<VatType> GetByNameAsync(string name, string CompanyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(CompanyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetFirstByExpression(p => p.Name == name && p.IsActive == true, default);
    }

    public async Task<ProductOptionsGetByIdDto> GetByIdForCheck(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var res = _queryRepository.GetAll()
        .Where(p => p.Id == id)
        .Include(p => p.Products)
        .Select(p => new ProductOptionsGetByIdDto(p.Products.FirstOrDefault().IsActive == true ? p.Products.FirstOrDefault().Name : null))
        .FirstOrDefault();
        return res;
    }
}
