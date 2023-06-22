using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.StateTransactionType;

public sealed record StateTransactionTypeCommand(
        int Id,
        string CompanyId,
        bool IsActive,
        string DeleterName
    ) : ICommand<StateTransactionTypeCommandResponse>;

