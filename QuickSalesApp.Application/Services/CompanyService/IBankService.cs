using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.CreateBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.UpdateBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetBank;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface IBankService
{
    Task CreateAsync(CreateBankCommand request, CancellationToken cancellationToken);
    Task<Bank> GetByNameAsync(string companyId, string name);
    Task<GetBankQueryResponse> GetBank(string companyId, int id);
    Task<Bank> GetByIdAsync(string companyId, int id);
    Task<Bank> RemoveByIdHard(string companyId, int id);
    Task<Bank> RemoveByIdSoft(string companyId, Bank bank);
    Task<Bank> UpdateAsync(UpdateBankCommand request);
    Task<PaginationResult<Bank>> GetAllActive(string companyId, int PageNumber, int PageSize);
    Task<Bank> ChangeState(string companyId, Bank bank);

    int GetCount(string companyId);
}
