using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.CreateTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.RemoveTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.UpdateTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetAllTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetTransactionType;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface ITransactionTypeService
{
    Task CreateAsync(CreateTransactionTypeCommand request, CancellationToken cancellationToken);
    Task<PaginationResult<TransactionType>> GetAllActive(GetAllTransactionTypeQuery request);
    Task<TransactionType> GetByIdAsync(int Id, string CompanyId);
    Task<TransactionType> RemoveByIdHard(RemoveTransactionTypeCommand request);
    Task<TransactionType> RemoveByIdSoft(string companyId, int id);
    Task<TransactionType> ChangeState(TransactionType transactionType, string companyId);
    Task<TransactionType> UpdateAsync(UpdateTransactionTypeCommand request);
    int GetCount(string companyId);
    Task<GetTransactionTypeQueryResponse> GetTransactionType(string companyId, int id);
}
