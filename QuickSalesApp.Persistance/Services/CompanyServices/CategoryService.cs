using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.UpdateCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllFilterCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetCategory;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos.ProductOptions;
using QuickSalesApp.Domain.Repositories.Company.CategoryRepositories;
using QuickSalesApp.Domain.Repositories.Company.ProductRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Utilities;

namespace QuickSalesApp.Persistance.Services.CompanyServices;

public sealed class CategoryService : ICategoryService
{

    private readonly ICategoryCommandRepository _categoryCommandRepository;
    private readonly ICategoryQueryRepository _categoryQueryRepository;
    private readonly IContextService _contextService;
    private CompanyDbContext _context;
    private readonly ICompanyDbUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IProductQueryRepository _productQueryRepository;

    public CategoryService(
        ICategoryCommandRepository categoryCommandRepository,
        ICategoryQueryRepository categoryQueryRepository,
        IContextService contextService, ICompanyDbUnitOfWork unitOfWork,
        IMapper mapper, IProductQueryRepository productQueryRepository)
    {
        _categoryCommandRepository = categoryCommandRepository;
        _categoryQueryRepository = categoryQueryRepository;
        _contextService = contextService;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _productQueryRepository = productQueryRepository;
    }

    public async Task<Category> ChangeState(string companyId, Category category)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);

        _categoryCommandRepository.Update(category);
        await _unitOfWork.SaveChangesAsync();
        return category;
    }

    public async Task CreateAsync(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _categoryCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Category category = _mapper.Map<Category>(request);
        await _categoryCommandRepository.AddAsync(category, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<PaginationResult<Category>> GetAllActive(string companyId, int pageNumber, int pageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryQueryRepository.SetDbContextInstance(_context);
        var result = await _categoryQueryRepository.GetAll().Where(p => p.IsActive == true && p.IsDelete == false).Include(p => p.Products).OrderBy(p => p.Id).ToPagedListAsync(pageNumber, pageSize);
        return result;
    }

    public async Task<Category> GetByIdAsync(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryQueryRepository.SetDbContextInstance(_context);
        return await _categoryQueryRepository.GetById(id);
    }

    public async Task<ProductOptionsGetByIdDto> GetByIdForCheck(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryQueryRepository.SetDbContextInstance(_context);
        var res = _categoryQueryRepository.GetAll()
        .Where(p => p.Id == id)
        .Include(p => p.Products)
        .Select(p => new ProductOptionsGetByIdDto(p.Products.FirstOrDefault().IsActive == true ? p.Products.FirstOrDefault().Name : null))
        .FirstOrDefault();
        return res;
    }

    public async Task<Category> GetByNameAsync(string companyId, string name)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryQueryRepository.SetDbContextInstance(_context);

        return await _categoryQueryRepository.GetFirstByExpression(p => p.Name == name && p.IsActive == true);
    }
    public async Task<GetCategoryQueryResponse> GetCategory(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryQueryRepository.SetDbContextInstance(_context);

        var category = await _categoryQueryRepository.GetWhere(x => x.Id == id).FirstOrDefaultAsync();
        var response = _mapper.Map<GetCategoryQueryResponse>(category);
        return response;
    }

    public async Task<Category> RemoveByIdHard(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Category category = await _categoryQueryRepository.GetById(id);
        await _categoryCommandRepository.RemoveById(id);
        await _unitOfWork.SaveChangesAsync();
        return category;
    }

    public async Task<Category> RemoveByIdSoft(string companyId, Category category)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        _categoryCommandRepository.Update(category);
        await _unitOfWork.SaveChangesAsync();

        return category;
    }
    public async Task<Category> UpdateAsync(UpdateCategoryCommand request)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _categoryCommandRepository.SetDbContextInstance(_context);
        _unitOfWork.SetDbContextInstance(_context);
        Category newCategory = _mapper.Map<Category>(request);
        newCategory.UpdateDate = DateTime.Now;
        _categoryCommandRepository.Update(newCategory);
        await _unitOfWork.SaveChangesAsync();

        return newCategory;
    }

    public int GetCount(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryQueryRepository.SetDbContextInstance(_context);
        return _categoryQueryRepository.GetAll().Count();
    }

    public async Task<PaginationResult<Category>> GetWithUnactive(string companyId, int pageNumber, int pageSize)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryQueryRepository.SetDbContextInstance(_context);
        var result = await _categoryQueryRepository.GetAll().Where(p => p.IsDelete == false).Include(p => p.Products).OrderBy(p => p.Id).ToPagedListAsync(pageNumber, pageSize);
        return result;
    }

    public async Task<PaginationResult<Category>> GetAllFilter(GetAllFilterCategoryQuery request)
    {

        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
        _categoryQueryRepository.SetDbContextInstance(_context);

        if (request.Expression == null)
        {
            var queryGetAll = _categoryQueryRepository.GetAll().Where(p => p.IsDelete == false)
                .OrderBy(p => p.Id);
            var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
            return resultGetAll;
        }

        var expression = ExpressionParser.ParseExpression<Category>(request.Expression);
        var query = _categoryQueryRepository.GetAll().Where(p => p.IsDelete == false)
            .Where(expression).OrderBy(p => p.Id);
        var result = await query.ToPagedListAsync(request.PageNumber, request.PageSize);
        return result;
    }

    public int GetCountbyFilter(string companyId, string expression)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryQueryRepository.SetDbContextInstance(_context);
        if (expression == null)
            return _categoryQueryRepository.GetAll().Count();

        var newExpression = ExpressionParser.ParseExpression<Category>(expression);
        return _categoryQueryRepository.GetAll().Where(p => p.IsDelete == false).Where(newExpression).OrderBy(p => p.Id).Count();
    }

    public async Task<IList<Category>> GetAllJustCategory(string companyId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryQueryRepository.SetDbContextInstance(_context);
        var result = await _categoryQueryRepository.GetAll().Where(p => p.IsDelete == false).OrderBy(p => p.Id).ToListAsync();

        return result;
    }

    public async Task<IList<Category>> GetAllProductByCategory(string companyId, int id)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _categoryQueryRepository.SetDbContextInstance(_context);
        _productQueryRepository.SetDbContextInstance(_context);

        var result = await _categoryQueryRepository.GetAll()
            .Where(c => c.IsDelete == false && c.Id == id)
            .Include(c => c.Products)
                .ThenInclude(p => p.ProductUnits)
            .Select(s => new Category
            {
                Id = s.Id,
                Name = s.Name,
                Products = s.Products.Where(p => p.ProductUnits.Any(u => u.Amount > 0) && p.IsActive == true && p.IsDelete == false).Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Code,
                    Photo = p.Photo,
                    VatType = p.VatType,
                    ProductUnits = p.ProductUnits.Select(p => new ProductUnit
                    {
                        Id = p.Id,
                        Price = p.Price,
                        UnitId = p.UnitId,
                        Unit = p.Unit,
                        IsVat = p.IsVat,
                        Amount = p.Amount,
                        Weight = p.Weight

                    }).Where(s => s.Amount > 0).ToList(),
                }).ToList()
            })
            .OrderBy(p => p.Id)
            .ToListAsync();

        return result;
    }



    public int GetProductCountByCategoryId(string companyId, int categoryId)
    {
        _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
        _productQueryRepository.SetDbContextInstance(_context);
        return _productQueryRepository.Count(x => x.CategoryId == categoryId && x.IsActive == true && x.IsDelete == false);
    }

}
