namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllProductBarcode;

public sealed record GetAllProductBarcodeQueryResponse(
        int Id,
        string Barcode,
        int ProductUnitId,
        bool? IsActive
      
    );