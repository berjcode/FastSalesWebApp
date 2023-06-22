using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.CreateProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.RemoveProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.UpdateProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetAllProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetByIdProductType;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos.ProductOptions;
using QuickSalesApp.Domain.Repositories.Company.ProductTypeRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class ProductTypeService : IProductTypeService
{
    private readonly IProductTypeCommandRepository _commandRepository;
    private readonly IProductTypeQueryRepository _queryRepository;
    private readonly IContextService _contextService;
    private readonly ICompanyDbUnitOfWork _companyDbUnitOfWork;
    private readonly IMapper _mapper;

    public ProductTypeService(IMapper mapper, ICompanyDbUnitOfWork companyDbUnitOfWork, IContextService contextService, IProductTypeQueryRepository queryRepository, IProductTypeCommandRepository commandRepository)
    {
        _mapper = mapper;
        _companyDbUnitOfWork = companyDbUnitOfWork;
        _contextService = contextService;
        _queryRepository = queryRepository;
        _commandRepository = commandRepository;
    }
    private CompanyDbContext _context;

    public async Task<ProductType> ChangeState(ProductType productType, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(productType);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return productType;
    }

    public async Task CreateAsync(CreateProductTypeCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductType type = _mapper.Map<ProductType>(request);

        await _commandRepository.AddAsync(type, cancellationToken);
        await _companyDbUnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<ProductType>> GetAllActive(GetAllProductTypeQuery request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _queryRepository.SetDbContextInstance(_context);
        var result = await _queryRepository.GetAll().Where(p => p.IsActive == true).OrderByDescending(p => p.CreatedDate).ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public async Task<ProductType> GetByIdAsync(int id, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetById(id);
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        return _queryRepository.GetAll().Count();
    }

    public async Task<ProductType> RemoveByIdHard(RemoveProductTypeCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _queryRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductType type = await _queryRepository.GetById(request.id);
        await _commandRepository.RemoveById(request.id);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return type;
    }

    public async Task<ProductType> RemoveByIdSoft(string companyId, ProductType type)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        _commandRepository.Update(type);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return type;
    }

    public async Task<ProductType> UpdateAsync(UpdateProductTypeCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _commandRepository.SetDbContextInstance(_context);
        _companyDbUnitOfWork.SetDbContextInstance(_context);

        ProductType type = _mapper.Map<ProductType>(request);
        _commandRepository.Update(type);
        await _companyDbUnitOfWork.SaveChangesAsync();
        return type;
    }

    public async Task<GetByIdProductTypeQueryResponse> GetProductType(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        var productType = await _queryRepository.GetWhere(x => x.Id == id).FirstOrDefaultAsync();
        var response = _mapper.Map<GetByIdProductTypeQueryResponse>(productType);
        return response;
    }

    public async Task<ProductType> GetByNameAsync(string Name, string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);

        return await _queryRepository.GetFirstByExpression(p => p.Name == Name && p.IsActive == true, default);
    }

    public async Task<ProductOptionsGetByIdDto> GetByIdForCheck(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _queryRepository.SetDbContextInstance(_context);
        var res = _queryRepository.GetAll()
        .Where(p => p.Id == id)
        .Include(p => p.Product)
        .Select(p => new ProductOptionsGetByIdDto(p.Product.FirstOrDefault().IsActive == true ? p.Product.FirstOrDefault().Name : null))
        .FirstOrDefault();
        return res;
    }
}
