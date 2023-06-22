using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;


namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllActiveCustomerType;

public sealed record GetAllActiveCustomerTypeQueryResponse (IList<CustomerType> CustomerTypes);

