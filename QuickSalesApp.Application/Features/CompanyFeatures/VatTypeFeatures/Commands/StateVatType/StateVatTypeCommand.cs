using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.StateVatType;

public sealed record StateVatTypeCommand(
        int Id,
        string CompanyId,
        bool IsActive,
        string DeleterName
    ) : ICommand<StateVatTypeCommandResponse>;
