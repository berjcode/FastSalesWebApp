using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.CreateDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.UpdateDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface IDepartmentService
{
    Task CreateAsync(CreateDepartmentCommand request, CancellationToken cancellationToken);
    Task<Department> GetByNameAsync(string companyId, string name);
    Task<GetDepartmentQueryResponse> GetDepartment(string companyId, int id);
    Task<Department> GetByIdAsync(string companyId, int id);
    Task<Department> RemoveByIdHard(string companyId, int id);
    Task<Department> RemoveByIdSoft(string companyId, Department department);
    Task<Department> UpdateAsync(UpdateDepartmentCommand request);
    Task<PaginationResult<Department>> GetAllActive(string companyId,int PageNumber, int PageSize);
    Task<Department> ChangeState(string companyId, Department department);
    
    int GetCount(string companyId);
     
    
}
