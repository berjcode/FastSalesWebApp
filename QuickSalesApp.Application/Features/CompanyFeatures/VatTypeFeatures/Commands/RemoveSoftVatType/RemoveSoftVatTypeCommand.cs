using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.RemoveSoftVatType;

public sealed record RemoveSoftVatTypeCommand(
        int id,
        string CompanyId,
        bool IsDelete,
        string DeleterName
    ) : ICommand<RemoveSoftVatTypeCommandResponse>;