using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.ProductBarcodeRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.ProductBarcodeRepositories
{
    public sealed class ProductBarcodeCommandRepository
        : CompanyDbCommandRepository<ProductBarcode>, IProductBarcodeCommandRepository
    {
    }
}
