

using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Queries.GetBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.CreateCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.UpdateCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetAllFilterCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetCustomerTransaction;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface ICustomerTransactionService
{

    Task CreateAsync(CreateCustomerTransactionCommand request, CancellationToken cancellationToken);
    Task<CustomerTransaction> GetByCodeAsync(string companyId, string customerCode);
    Task<GetCustomerTransactionQueryResponse> GetCustomerTransaction(string companyId, int id);
    Task<CustomerTransaction> GetByIdAsync(string companyId, int id);
    Task<CustomerTransaction> RemoveByIdHard(string companyId, int id);
    Task<CustomerTransaction> RemoveByIdSoft(string companyId, CustomerTransaction customerTransaction);
    Task<CustomerTransaction> UpdateAsync(UpdateCustomerTransactionCommand request);
    Task<PaginationResult<CustomerTransaction>> GetAllActive(string companyId, int PageNumber, int PageSize);
    Task<CustomerTransaction> ChangeState(string companyId, CustomerTransaction customerTransaction);
    Task<PaginationResult<CustomerTransaction>> GetAllFilter(GetAllFilterCustomerTransactionQuery request);
    int GetCountByFilter(string companyId, string expression, string search);
    int GetCount(string companyId);

}
