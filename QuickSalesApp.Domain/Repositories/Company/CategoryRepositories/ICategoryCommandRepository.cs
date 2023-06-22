using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.CategoryRepositories;

public  interface ICategoryCommandRepository :ICompanyDbCommandRepository<Category>
{

}
