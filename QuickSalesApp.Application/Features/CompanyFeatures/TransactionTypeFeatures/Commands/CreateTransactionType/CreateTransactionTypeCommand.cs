using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.CreateTransactionType;

public sealed record CreateTransactionTypeCommand(
        string Name,
        int Order,
        string CreatorName,
        string CompanyId
    ) : ICommand<CreateTransactionTypeCommandResponse>;

