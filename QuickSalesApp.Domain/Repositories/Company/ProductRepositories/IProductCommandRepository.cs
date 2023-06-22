using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;
namespace QuickSalesApp.Domain.Repositories.Company.ProductRepositories;

public interface IProductCommandRepository : ICompanyDbCommandRepository<Product>
{
}
