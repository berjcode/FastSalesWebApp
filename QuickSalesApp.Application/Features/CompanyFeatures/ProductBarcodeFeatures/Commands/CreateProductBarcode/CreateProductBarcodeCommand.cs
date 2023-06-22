using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.CreateProductBarcode;

public sealed record CreateProductBarcodeCommand(
         int ProductUnitId,
         string Barcode,
         string CompanyId,
         string CreatorName
    ) : ICommand<CreateProductBarcodeCommandResponse>;
