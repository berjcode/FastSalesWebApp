using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.UpdateProductBarcode;

public sealed record UpdateProductBarcodeCommand(
        int Id,
        int ProductUnitId,
        string Barcode,
        string CompanyId,
        string UpdaterName
    ) : ICommand<UpdateProductBarcodeCommandResponse>;
