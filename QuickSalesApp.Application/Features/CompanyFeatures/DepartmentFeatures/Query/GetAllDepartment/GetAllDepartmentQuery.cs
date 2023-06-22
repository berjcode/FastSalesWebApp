

using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetAllDepartment;

public sealed record GetAllDepartmentQuery (
    string CompanyId,
    int PageNumber,
    int PageSize 

    ) : IQuery<PaginationResult<GetAllDepartmentQueryResponse>>;

