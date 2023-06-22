using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllFilterCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.CreateCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.UpdateCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllFilterCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetCustomerType;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Services.CompanyService;

public interface ICustomerTypeService
{
    Task CreateAsync(CreateCustomerTypeCommand request, CancellationToken cancellationToken);
    Task<CustomerType> GetByNameAsync(string companyId, string name);
    Task<GetCustomerTypeQueryResponse> GetDepartment(string companyId, int id);
    Task<CustomerType> GetByIdAsync(string companyId, int id);
    Task<CustomerType> RemoveByIdHard(string companyId, int id);
    Task<CustomerType> RemoveByIdSoft(string companyId, CustomerType customerType);
    Task<CustomerType> UpdateAsync(UpdateCustomerTypeCommand request);
    Task<IList<CustomerType>> GetAllActive(string companyId);
    Task<PaginationResult<CustomerType>> GetAll(string companyId, int PageNumber, int PageSize);
    Task<CustomerType > ChangeState(string companyId, CustomerType customerType);

    int GetCount(string companyId);
    int GetCountByFilter(string companyId, string expression);
    Task<PaginationResult<CustomerType>> GetAllFilter(GetAllFilterCustomerTypeQuery request);
}
