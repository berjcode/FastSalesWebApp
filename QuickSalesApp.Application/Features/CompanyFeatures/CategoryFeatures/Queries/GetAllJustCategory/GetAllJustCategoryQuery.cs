using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllJustCategory;

public sealed record GetAllJustCategoryQuery(
    string CompanyId
   
    ) : IQuery<IList<GetAllJustCategoryQueryResponse>>;

