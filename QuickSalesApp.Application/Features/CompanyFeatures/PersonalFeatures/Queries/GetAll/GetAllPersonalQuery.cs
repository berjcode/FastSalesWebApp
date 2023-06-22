using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetAll
{
    public sealed record GetAllPersonalQuery(
            string CompanyId,
            int PageNumber,
            int PageSize
        ) : IQuery<PaginationResult<GetAllPersonalQueryResponse>>;
}
