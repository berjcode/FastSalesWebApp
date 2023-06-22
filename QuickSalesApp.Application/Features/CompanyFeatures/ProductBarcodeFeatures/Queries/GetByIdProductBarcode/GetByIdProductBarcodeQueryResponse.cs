using Newtonsoft.Json;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllBasketProductbyBarcode;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetByIdProductBarcode;

public sealed record GetByIdProductBarcodeQueryResponse(
            string Barcode,
            string ProductUnitProductCode,
            DateTime? CreatedDate,
            string UpdaterName,
            DateTime? UpdateDate,
            bool? IsActive
    );


