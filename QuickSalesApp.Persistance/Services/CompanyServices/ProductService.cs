using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using Microsoft.EntityFrameworkCore;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.UpdateProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllByFilterProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetByIdProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetProductLastCode;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.ProductBarcodeRepositories;
using QuickSalesApp.Domain.Repositories.Company.ProductRepositories;
using QuickSalesApp.Domain.Repositories.Company.ProductUnitRepositories;
using QuickSalesApp.Domain.UnitOfWork;
using QuickSalesApp.Persistance.Context;
using QuickSalesApp.Persistance.Utilities;
using System.Text.RegularExpressions;

namespace QuickSalesApp.Persistance.Services.CompanyServices
{
    public sealed class ProductService : IProductService
    {
        private readonly IProductCommandRepository _commandRepository;
        private readonly IProductUnitCommandRepository _unitCommandRepository;
        private readonly IProductBarcodeCommandRepository _productBarcodeCommandRepository;
        private readonly IProductQueryRepository _queryRepository;
        private readonly IProductBarcodeQueryRepository _productBarcodeQueryRepository;
        private readonly IContextService _contextService;
        private CompanyDbContext _context;
        private readonly ICompanyDbUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IProductCommandRepository commandRepository, IContextService contextService
            , ICompanyDbUnitOfWork unitOfWork, IMapper mapper, IProductQueryRepository queryRepository, IProductBarcodeQueryRepository productBarcodeQueryRepository, IProductUnitCommandRepository unitCommandRepository, IProductBarcodeCommandRepository productBarcodeCommandRepository)
        {
            _commandRepository = commandRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _queryRepository = queryRepository;
            _productBarcodeQueryRepository = productBarcodeQueryRepository;
            _unitCommandRepository = unitCommandRepository;
            _productBarcodeCommandRepository = productBarcodeCommandRepository;
        }

        public async Task CreateAsync(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitCommandRepository.SetDbContextInstance(_context);
            _productBarcodeCommandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            Product product = _mapper.Map<Product>(request);

            product.Code = await generateCode(request.Code.ToUpper(), request.CompanyId);

            await _commandRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            ProductUnit productUnit = new()
            {
                ProductId = product.Id,
                Factor = request.Factor,
                IsDefault = request.IsDefault,
                Price = request.Price,
                UnitId = request.UnitId,
                IsVat = request.IsVat,
                Amount = 10
            };
            await _unitCommandRepository.AddAsync(productUnit, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            if(request.Barcode != null)
            {
                ProductBarcode barcode = new()
                {
                    ProductUnitId = productUnit.Id,
                    Barcode = request.Barcode
                };
                await _productBarcodeCommandRepository.AddAsync(barcode, cancellationToken);
                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }
        }

        public async Task<Product> GetByCodeAsync(string code, string CompanyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(CompanyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetWhere(p => p.Code == code).FirstOrDefaultAsync();
        }

        public async Task<PaginationResult<Product>> GetAllActive(string companyId, int pageNumber, int pageSize)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            var result = await _queryRepository.GetAll().Where(p => p.IsActive == true).OrderByDescending(p => p.CreatedDate).Include(p => p.Category).Include(p => p.ProductType).Include(p => p.VatType).ToPagedListAsync(pageNumber, pageSize);
            return result;
        }

        public async Task<Product> GetByNameAsync(string name, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetWhere(p => p.Name == name).FirstOrDefaultAsync();
        }

        public async Task<Product> GetByIdAsync(int id, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return await _queryRepository.GetById(id);
        }

        public async Task<Product> RemoveByIdHard(int id, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            _queryRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            Product product = await _queryRepository.GetById(id);
            await _commandRepository.RemoveById(id);
            await _unitOfWork.SaveChangesAsync();
            return product;
        }

        public async Task<Product> ChangeState(Product product, string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);

            _commandRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(UpdateProductCommand request)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            Product newProduct = _mapper.Map<Product>(request);
            newProduct.UpdateDate = DateTime.Now;
            _commandRepository.Update(newProduct);
            await _unitOfWork.SaveChangesAsync();

            return newProduct;
        }

        public int GetCount(string companyId)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            return _queryRepository.GetAll().Count();
        }

        public async Task<Product> RemoveByIdSoft(string companyId, Product product)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _commandRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);

            _commandRepository.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return product;
        }

        public async Task<GetByIdProductQueryResponse> GetProduct(string companyId, int id)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);

            var productType = await _queryRepository.GetWhere(x => x.Id == id).Include(p => p.Category).Include(p => p.ProductType).Include(p => p.VatType).FirstOrDefaultAsync();
            var response = _mapper.Map<GetByIdProductQueryResponse>(productType);
            return response;
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
            return  data.Count();
        }

        public async Task<PaginationResult<Product>> GetAllFilter(GetAllByFilterProductQuery request)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _queryRepository.SetDbContextInstance(_context);
            _productBarcodeQueryRepository.SetDbContextInstance(_context);
            if (request.Expression == null)
            {
                var queryGetAll = _queryRepository.GetAll()
                    .Where(p => p.IsDelete == false)
                    .OrderBy(p => p.Id)
                    .Include(p => p.Category)
                    .Include(p => p.ProductType)
                    .Include(p => p.VatType);
                var resultGetAll = await queryGetAll.ToPagedListAsync(request.PageNumber, request.PageSize);
                return resultGetAll;
            }
            var expression = ExpressionParser.ParseExpression<Product>(request.Expression);
            var query = _queryRepository.GetAll().Where(p => p.IsDelete == false).Where(expression).Include(p => p.Category).Include(p => p.ProductType).Include(p => p.VatType);
            var result = await query.ToPagedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public int GetCountbyFilter(string companyId, string expression)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(companyId);
            _queryRepository.SetDbContextInstance(_context);
            if (expression == null)
                return _queryRepository.GetAll().Count();

            var newExpression = ExpressionParser.ParseExpression<Product>(expression);
            return _queryRepository.GetAll().Where(p => p.IsDelete == false).Where(newExpression).OrderBy(p => p.Id).Include(p => p.Category).Include(p => p.ProductType).Include(p => p.VatType).Count();
        }

        public string GetLastCode(GetProductLastCodeQuery request)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContextInstance(request.CompanyId);
            _queryRepository.SetDbContextInstance(_context);
            var result = _queryRepository.GetAll();
            var lastItem = result.OrderBy(p => p.Id).Last();
            Match match = Regex.Match(lastItem.Code, @"\d+");
            if (match.Success)
            {
                int number = int.Parse(match.Value);
                number++;
                string replacedString = lastItem.Code.Replace(match.Value, number.ToString("D3"));
                return replacedString;
            }
            return "";
        }
    }
}
