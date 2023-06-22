using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.CreateBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.UpdateBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.CreateDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
namespace QuickSalesApp.Application.Services.CompanyService;

public interface IBankAccountService
{
    Task CreateAsync(CreateBankAccountCommand request, CancellationToken cancellationToken);
    Task<BankAccount> GetByNameAsync(string companyId, string name);
    Task<GetBankAccountQueryResponse> GetBankAccount(string companyId, int id);
    Task<BankAccount> GetByIdAsync(string companyId, int id);
    Task<BankAccount> RemoveByIdHard(string companyId, int id);
    Task<BankAccount> RemoveByIdSoft(string companyId, BankAccount bankAccount);
    Task<BankAccount> UpdateAsync(UpdateBankAccountCommand request);
    Task<PaginationResult<BankAccount>> GetAllActive(string companyId, int PageNumber, int PageSize);
    Task<BankAccount> ChangeState(string companyId, BankAccount bankAccount);

    int GetCount(string companyId);
}
