using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.StateProductTransaction;

public sealed record StateProductTransactionCommand(
        int Id,
        string CompanyId,
        bool IsActive,
        string DeleterName
    ) :  ICommand<StateProductTransactionCommandResponse>;