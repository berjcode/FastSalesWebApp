using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.CreateBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankBankAccountFeatures.Commands.CreateBankBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankBankAccountFeatures.Queries.GetBankBankAccount;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface IBankBankAccountService
{

    Task CreateAsync(BankBankAccount bankBankAccount, CancellationToken cancellationToken);
    Task<BankBankAccount> GetByNameAsync(string companyId, string name);
    Task<GetBankBankAccountQueryResponse> GetBankBankAccount(string companyId, int id);
    Task<BankBankAccount> GetByIdAsync(string companyId, int id);
    Task<BankBankAccount> RemoveByIdHard(string companyId, int id);
    Task<BankBankAccount> RemoveByIdSoft(string companyId, BankBankAccount bankBankAccount);
    Task<BankBankAccount> UpdateAsync(BankBankAccount bankBankAccount, string companyId);
    Task<PaginationResult<BankBankAccount>> GetAllActive(string companyId, int PageNumber, int PageSize);
    Task<BankBankAccount> ChangeState(string companyId, BankBankAccount bankBankAccount);

    int GetCount(string companyId);
}
