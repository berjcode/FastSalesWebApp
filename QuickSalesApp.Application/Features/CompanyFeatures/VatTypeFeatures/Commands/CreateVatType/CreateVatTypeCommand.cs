using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.CreateVatType;

public sealed record CreateVatTypeCommand(
        string Name,
        int Value,
        string CreatorName,
        string CompanyId
    ) : ICommand<CreateVatTypeCommandResponse>;