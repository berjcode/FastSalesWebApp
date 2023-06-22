using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.CategoryRepositories;

public interface ICategoryQueryRepository : ICompanyDbQueryRepository<Category>
{
}
