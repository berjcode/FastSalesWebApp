using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.CreateSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.RemoveSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.UpdateSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetAllSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetByIdSafe;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface ISafeService
{
    Task CreateAsync(CreateSafeCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<Safe>> GetAllActive(GetAllSafeQuery request);
    Task<Safe> GetByIdAsync(int Id, string CompanyId);
    Task<Safe> GetByNameAsync(string Name, string CompanyId);
    Task<Safe> RemoveByIdHard(RemoveSafeCommand request);
    Task<Safe> RemoveByIdSoft(string companyId, int id);
    Task<Safe> ChangeState(Safe safe, string companyId);
    Task<Safe> UpdateAsync(UpdateSafeCommand request);
    int GetCount(string companyId);
    Task<GetByIdSafeQueryResponse> GetSafe(string companyId, int id);
}
