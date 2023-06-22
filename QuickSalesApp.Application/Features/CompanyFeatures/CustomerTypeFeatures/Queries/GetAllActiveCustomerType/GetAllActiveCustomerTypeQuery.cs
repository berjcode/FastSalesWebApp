

using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllActiveCustomerType;

public sealed record GetAllActiveCustomerTypeQuery(
    string CompanyId


    ) : IQuery<GetAllActiveCustomerTypeQueryResponse>;

