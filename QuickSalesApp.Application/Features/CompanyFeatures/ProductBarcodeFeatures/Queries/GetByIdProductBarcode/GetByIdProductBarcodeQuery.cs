using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetByIdProductBarcode;

public sealed record GetByIdProductBarcodeQuery(
        int Id,
        string CompanyId
    ) : IQuery<GetByIdProductBarcodeQueryResponse>;
