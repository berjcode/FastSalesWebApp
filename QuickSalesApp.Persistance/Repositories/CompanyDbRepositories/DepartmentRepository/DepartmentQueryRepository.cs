using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Repositories.Company.DepartmentRepositories;
using QuickSalesApp.Persistance.Repositories.GenericRepositories.CompanyDbRepositories;

namespace QuickSalesApp.Persistance.Repositories.CompanyDbRepositories.DepartmentRepository;

public sealed class DepartmentQueryRepository  : CompanyDbQueryRepository<Department>, IDepartmentQueryRepository
{
}
