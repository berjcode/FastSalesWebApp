using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.CreateProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.RemoveProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.UpdateProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllBasketProductbyBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllByFilterProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetByIdProductBarcode;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.ProductBarcodeRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Utilities;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class ProductBarcodeService : IProductBarcodeService
{
    private readonly IProductBarcodeCommandRepository _commandRepository;
    private readonly IProductBarcodeQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
    private readonly IMapper _mapper;

    public ProductBarcodeService(IMapper mapper, ICompanyDbUnitOfWork companyDbUnitOfWork, IContextService contextService, IProductBarcodeQueryRepository queryRepository, IProductBarcodeCommandRepository commandRepository)
    {
        _mapper = mapper;
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _contextService = contextService;
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
    }

    private CompanyDbContext _context;


    public async Task<ProductBarcode> ChangeState(ProductBarcode productBarcode, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(productBarcode);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return productBarcode;
    }

    public async Task CreateAsync(CreateProductBarcodeCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductBarcode productBarcode = _mapper.Map<ProductBarcode>(request);

        await _commandRepository.AddAsync(productBarcode, cancellationToken);
        await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);

    }

    public async Task<PaginationResult<ProductBarcode>> GetAllActive(GetAllProductBarcodeQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true).OrderByDescending(p => p.CreatedDate).Include(p => p.ProductUnit).ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public async Task<ProductBarcode> GetByIdAsync(int id, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetById(id);
    }

    public async Task<ProductBarcode> RemoveByIdHard(RemoveProductBarcodeCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductBarcode productBarcode = await _queryRepository.GetById(request.Id);
        await _commandRepository.RemoveById(request.Id);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return productBarcode;
    }

    public async Task<ProductBarcode> UpdateAsync(UpdateProductBarcodeCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductBarcode newProductBarcode = _mapper.Map<ProductBarcode>(request);
        _commandRepository.Update(newProductBarcode);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return newProductBarcode;
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }

    public async Task<ProductBarcode> RemoveByIdSoft(string companyId, ProductBarcode barcode)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(barcode);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return barcode;
    }

    public async Task<GetByIdProductBarcodeQueryResponse> GetProductBarcode(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var productType = await _queryRepository.GetWhere(x => x.Id == id).Include(p => p.ProductUnit).FirstOrDefaultAsync();
        var response = _mapper.Map<GetByIdProductBarcodeQueryResponse>(productType);
        return response;
    }

    public async  Task<GetAllBasketProductbyBarcodeQueryResponse> GetAllBasketProductByBarcode(string companyId, string barcode)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var barcodeByProduct = await _queryRepository.GetWhere(x => x.Barcode == barcode).Include(x=> x.ProductUnit).ThenInclude(x=> x.Product).ThenInclude(x=> x.VatType).FirstOrDefaultAsync();
        var response = _mapper.Map<GetAllBasketProductbyBarcodeQueryResponse>(barcodeByProduct);
        return response;
    }

    public async Task<PaginationResult<ProductBarcode>> GetAllFilter(GetAllByFilterProductBarcodeQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        if (request.Expression == null)
        {
            var queryGetAll = _queryRepository.GetAll().Where(p => p.IsDelete == false).OrderBy(p => p.Id).Include(p => p.ProductUnit);
            var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAll;
        }
        var expression = ExpressionParser.ParseExpression<ProductBarcode>(request.Expression);
        var query = _queryRepository.GetAll().Where(p => p.IsDelete == false).Where(expression).Include(p => p.ProductUnit);
        var result = await query.ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public int GetCountbyFilter(string companyId, string expression)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        if (expression == null)
            return _queryRepository.GetAll().Count();

        var newExpression = ExpressionParser.ParseExpression<ProductBarcode>(expression);
        return _queryRepository.GetAll().Where(p => p.IsDelete == false).Where(newExpression).OrderBy(p => p.Id).Include(p => p.ProductUnit).Count();
    }

    public async Task<ProductBarcode> GetByCodeAsync(string Barcode, string CompanyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(CompanyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetFirstByExpression(p => p.Barcode == Barcode);
    }

  
}
