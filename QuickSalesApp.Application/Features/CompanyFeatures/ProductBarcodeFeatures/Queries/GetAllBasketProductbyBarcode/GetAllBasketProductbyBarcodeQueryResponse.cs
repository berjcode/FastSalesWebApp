namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllBasketProductbyBarcode;

public sealed record GetAllBasketProductbyBarcodeQueryResponse(
      int ProductUnitProductId, 
      string ProductUnitProductName,
      bool ProductUnitIsVat,    
      string ProductUnitProductCode,
      decimal ProductUnitPrice,
      int ProductUnitProductVatTypeValue
      
    );



 