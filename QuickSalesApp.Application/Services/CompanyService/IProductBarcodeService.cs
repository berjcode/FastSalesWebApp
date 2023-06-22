using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.CreateProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.RemoveProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.UpdateProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllBasketProductbyBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllByFilterProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetByIdProductBarcode;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services;

public interface IProductBarcodeService
{
    Task CreateAsync(CreateProductBarcodeCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<ProductBarcode>> GetAllActive(GetAllProductBarcodeQuery request);
    Task<ProductBarcode> GetByIdAsync(int id, string companyId);
    Task<ProductBarcode> RemoveByIdHard(RemoveProductBarcodeCommand request);
    Task<ProductBarcode> RemoveByIdSoft(string companyId, ProductBarcode barcode);
    Task<ProductBarcode> ChangeState(ProductBarcode productBarcode, string companyId);
    Task<ProductBarcode> UpdateAsync(UpdateProductBarcodeCommand request);
    int GetCount(string companyId);
    Task<GetByIdProductBarcodeQueryResponse> GetProductBarcode(string companyId, int id);
    Task<GetAllBasketProductbyBarcodeQueryResponse> GetAllBasketProductByBarcode(string companyId, string barcode);
    Task<PaginationResult<ProductBarcode>> GetAllFilter(GetAllByFilterProductBarcodeQuery request);
    int GetCountbyFilter(string companyId, string expression);
    Task<ProductBarcode> GetByCodeAsync(string Barcode, string CompanyId);
}
