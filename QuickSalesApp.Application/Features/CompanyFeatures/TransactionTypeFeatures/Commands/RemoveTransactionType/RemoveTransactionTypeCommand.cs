using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.RemoveTransactionType;

public sealed record RemoveTransactionTypeCommand(
    int id,
    string CompanyId
    ) : ICommand<RemoveTransactionTypeCommandResponse>;
