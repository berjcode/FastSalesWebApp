using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.RemoveSoftTransactionType;

public sealed record RemoveSoftTransactionTypeCommand(
    int id,
    string CompanyId
    ) : ICommand<RemoveSoftTransactionTypeCommandResponse>;
