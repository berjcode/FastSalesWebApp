using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.StateSafeTransaction;

public sealed record StateSafeTransactionCommand(
        int Id,
        string CompanyId,
        bool IsActive,
        string DeleterName
    ) : ICommand<StateSafeTransactionCommandResponse>;