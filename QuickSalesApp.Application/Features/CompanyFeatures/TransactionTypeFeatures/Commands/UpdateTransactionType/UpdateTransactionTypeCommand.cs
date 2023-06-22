using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.UpdateTransactionType;

public sealed record UpdateTransactionTypeCommand(
        int Id,
        string Name,
        int Order,
        string UpdaterName,
        string CompanyId
    ) : ICommand<UpdateTransactionTypeCommandResponse>;