using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.CreateSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.RemoveSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.UpdateSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetAllSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetSafeTransaction;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface ISafeTransactionService
{
    Task CreateAsync(CreateSafeTransactionCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<SafeTransaction>> GetAllActive(GetAllSafeTransactionQuery request);
    Task<SafeTransaction> GetByIdAsync(int id, string companyId);
    Task<SafeTransaction> RemoveByIdHard(RemoveSafeTransactionCommand request);
    Task<SafeTransaction> RemoveByIdSoft(string companyId, int id);
    Task<SafeTransaction> ChangeState(SafeTransaction safeTransaction, string companyId);
    Task<SafeTransaction> UpdateAsync(UpdateSafeTransactionCommand request);
    int GetCount(string companyId);
    Task<GetSafeTransactionQueryResponse> GetSafeTransaction(string companyId, int id);
}
