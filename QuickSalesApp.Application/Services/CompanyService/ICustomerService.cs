using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.UpdateCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllFilterCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllGroupCodes;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetLastCode;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface ICustomerService
{

    Task CreateAsync(CreateCustomerCommand request, CancellationToken cancellationToken);
    Task<Customer> GetByNameAsync(string companyId, string name);
    Task<PaginationResult<Customer>> GetAllFilter(GetAllFilterCustomerQuery request);
    Task<GetCustomerQueryResponse> GetCustomer(string companyId, int id);
    int  GetCountbyFilter(string companyId, string expression, string search);
    Task<Customer> GetByIdAsync(string companyId, int id);
    Task<Customer> RemoveByIdHard(string companyId, int id);
    Task<Customer> RemoveByIdSoft(string companyId, Customer customer);
    Task<Customer> UpdateAsync(UpdateCustomerCommand request);
    Task<PaginationResult<Customer>> GetAll(string companyId, int pageNumber, int pageSize);
    Task<List<Customer>> GetAllActive(string companyId);
    Task<Customer> ChangeState(string companyId, Customer customer);
    int GetCount(string companyId);
    Task<GetAllGroupCodesQueryResponse> GetGroupCodes(GetAllGroupCodesQuery request);
    string GetLastCode(GetLastCodeQuery request);
}
