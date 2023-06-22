using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllBasketProductbyBarcode;

public sealed record GetAllBasketProductbyBarcodeQuery(
    string CompanyId,
    string Barcode

    ) : IQuery<GetAllBasketProductbyBarcodeQueryResponse>;
