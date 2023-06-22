using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.BankBankAccountFeatures.Commands.CreateBankBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankBankAccountFeatures.Queries.GetBankBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.CreateBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.UpdateBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Queries.GetBankTransaction;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService;
public interface IBankTransactionService
{

    Task CreateAsync(CreateBankTransactionCommand request, CancellationToken cancellationToken);
    Task<BankTransaction> GetByNameAsync(string companyId, string bankCode);
    Task<GetBankTransactionQueryResponse> GetBankTransaction(string companyId, int id);
    Task<BankTransaction> GetByIdAsync(string companyId, int id);
    Task<BankTransaction> RemoveByIdHard(string companyId, int id);
    Task<BankTransaction> RemoveByIdSoft(string companyId, BankTransaction bankTransaction);
    Task<BankTransaction> UpdateAsync(UpdateBankTransactionCommand request);
    Task<PaginationResult<BankTransaction>> GetAllActive(string companyId, int PageNumber, int PageSize);
    Task<BankTransaction> ChangeState(string companyId, BankTransaction bankTransaction);

    int GetCount(string companyId);
}
