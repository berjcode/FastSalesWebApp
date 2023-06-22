using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllByFilterProductBarcode;

public sealed record GetAllByFilterProductBarcodeQuery(
        string CompanyId,
        string Expression,
        int PageNumber,
        int PageSize
    ) : IQuery<PaginationResult<GetAllByFilterProductBarcodeQueryResponse>>;
