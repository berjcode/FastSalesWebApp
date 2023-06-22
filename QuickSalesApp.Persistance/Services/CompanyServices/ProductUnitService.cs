using AutoMapper;
using Azure.Core;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.CreateProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.RemoveProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.UpdateProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllByFilterProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllForProductList;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetByIdProductUnit;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.ProductUnitRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Utilities;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class ProductUnitService : IProductUnitService
{
    private readonly IProductUnitCommandRepository _commandRepository;
    private readonly IProductUnitQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
    private readonly IMapper _mapper;

    public ProductUnitService(IMapper mapper, ICompanyDbUnitOfWork companyDbUnitOfWork, IContextService contextService, IProductUnitQueryRepository queryRepository, IProductUnitCommandRepository commandRepository)
    {
        _mapper = mapper;
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _contextService = contextService;
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
    }

    private CompanyDbContext _context;


    public async Task<ProductUnit> ChangeState(ProductUnit productUnit, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(productUnit);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return productUnit;
    }

    public async Task CreateAsync(CreateProductUnitCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductUnit unit = _mapper.Map<ProductUnit>(request);

        await _commandRepository.AddAsync(unit, cancellationToken);
        await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<ProductUnit>> GetAllActive(GetAllProductUnitQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true).OrderByDescending(p => p.CreatedDate).Include(p => p.Unit).ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public async Task<ProductUnit> GetByIdAsync(int Id, string CompanyId)
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

    public async Task<GetByIdProductUnitQueryResponse> GetProductUnit(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var productUnit = await _queryRepository.GetWhere(x => x.Id == id).Include(p => p.Unit).FirstOrDefaultAsync();
        var response = _mapper.Map<GetByIdProductUnitQueryResponse>(productUnit);
        return response;
    }

    public async Task<ProductUnit> RemoveByIdHard(RemoveProductUnitCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductUnit unit = await _queryRepository.GetById(request.Id);
        await _commandRepository.RemoveById(request.Id);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return unit;
    }

    public async Task<ProductUnit> RemoveByIdSoft(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductUnit unit = await _queryRepository.GetById(id);
        unit.IsActive = false;
        unit.IsDelete = true;
        _commandRepository.Update(unit);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return unit;
    }

    public async Task<ProductUnit> UpdateAsync(UpdateProductUnitCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductUnit unit = _mapper.Map<ProductUnit>(request);
        _commandRepository.Update(unit);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return unit;
    }

    public async Task<PaginationResult<ProductUnit>> GetAllFilter(GetAllByFilterProductUnitQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        if (request.search != null)
        {
            var queryGetAll = _queryRepository.GetAll().Where(p => p.IsDelete == false && p.Product.Name.Contains(request.search)).OrderBy(p => p.Id).Include(p => p.Unit).Include(p => p.ProductBarcode).Include(p => p.Product);
            var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAll;
        }
        if (request.Expression == null)
        {
            var queryGetAll = _queryRepository.GetAll().Where(p => p.IsDelete == false).OrderBy(p => p.Id).Include(p => p.Unit);
            var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAll;
        }
        var expression = ExpressionParser.ParseExpression<ProductUnit>(request.Expression);
        var query = _queryRepository.GetAll().Where(p => p.IsDelete == false).Where(expression).Include(p => p.Unit);
        var result = await query.ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public int GetCountbyFilter(string companyId, string expression, string search)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        if (expression == null)
            return _queryRepository.GetAll().Include(p => p.Product).Where(p => p.Product.IsDelete == false).Count();
        var newExpression = ExpressionParser.ParseExpression<ProductUnit>(expression);
        if (search == null && expression != null)
        {
            return _queryRepository.GetAll()
                .Include(p => p.Product).Where(p => p.Product.IsDelete == false).Where(newExpression).Count();
        }
        return _queryRepository.GetAll().Include(p => p.Product).Where(p => p.Product.IsDelete == false).Where(newExpression).Count();
    }

    public async Task<PaginationResult<ProductUnit>> GetAllFilterForProduct(GetAllForProductListQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        if (request.search != null)
        {
            var queryGetAll = _queryRepository
                .GetAll()
                .Where(p => p.Product.IsDelete == false && p.Product.Name.Contains(request.search))
                .OrderBy(p => p.Id)
                .Include(p => p.Unit)
                .Include(p => p.ProductBarcode)
                .Include(p => p.Product)
                .ThenInclude(p => p.VatType);
            var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAll;
        }
        if (request.Expression == null)
        {
            var queryGetAll = _queryRepository
                .GetAll()
                .Where(p => p.Product.IsDelete == false)
                .OrderBy(p => p.Id)
                .Include(p => p.Unit)
                .Include(p => p.ProductBarcode)
                .Include(p => p.Product)
                .ThenInclude(p => p.VatType);
            var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAll;
        }
        var expression = ExpressionParser.ParseExpression<ProductUnit>(request.Expression);
        var query = _queryRepository
            .GetAll()
            .Where(p => p.Product.IsDelete == false)
            .Where(expression)
            .OrderBy(p => p.Id)
            .Include(p => p.Unit)
            .Include(p => p.ProductBarcode)
            .Include(p => p.Product)
            .ThenInclude(p => p.VatType);
        var result = await query.ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }
}
