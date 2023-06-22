namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllByFilterProductBarcode;

public sealed record GetAllByFilterProductBarcodeQueryResponse(
        int Id,
        string Barcode,
        int ProductUnitId,
        bool? IsActive       
    );
