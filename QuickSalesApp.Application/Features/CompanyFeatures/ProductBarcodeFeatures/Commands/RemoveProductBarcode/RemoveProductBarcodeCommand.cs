using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.RemoveProductBarcode;

public sealed record RemoveProductBarcodeCommand(
        int Id,
        string CompanyId
    ) : ICommand<RemoveProductBarcodeCommandResponse>;
