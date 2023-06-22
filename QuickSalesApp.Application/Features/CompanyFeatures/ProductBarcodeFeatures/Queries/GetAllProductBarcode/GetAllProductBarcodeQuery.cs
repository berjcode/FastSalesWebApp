using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllProductBarcode;

public sealed record GetAllProductBarcodeQuery(
    string CompanyId,
    int PageNumber,
    int PageSize
    ) : IQuery<PaginationResult<GetAllProductBarcodeQueryResponse>>;
