using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.GenericRepositories.CompanyDbContext;

namespace QuickSalesApp.Domain.Repositories.Company.DepartmentRepositories;

public  interface IDepartmentQueryRepository :ICompanyDbQueryRepository<Department>
{
}
