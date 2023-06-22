using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetBasketUnit;

public sealed record GetBasketUnitQuery(
        string CompanyId
       
    ) : IQuery<GetBasketUnitQueryResponse>;