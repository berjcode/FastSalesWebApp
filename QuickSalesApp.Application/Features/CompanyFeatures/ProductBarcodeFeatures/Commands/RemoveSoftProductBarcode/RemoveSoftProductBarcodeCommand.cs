using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.RemoveSoftProductBarcode;

public sealed record RemoveSoftProductBarcodeCommand(
        int id,
        string CompanyId,
        bool IsDelete,
        string DeleterName
    ) : ICommand<RemoveSoftProductBarcodeCommandResponse>;
