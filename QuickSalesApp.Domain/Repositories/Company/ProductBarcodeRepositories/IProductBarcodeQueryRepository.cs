using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.ProductBarcodeRepositories
{
    public interface IProductBarcodeQueryRepository
        : ICompanyDbQueryRepository<ProductBarcode>
    {
    }
}
