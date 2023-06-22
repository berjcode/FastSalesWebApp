using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.CreateSafeTransaction;

public sealed record CreateSafeTransactionCommand(
        string PlugNo,
        string SafeCode,
        DateTime? TransactionDate,
        string Text,
        decimal Debt,
        decimal Credit,
        decimal Remainder,
        int ProcessTypeId,
        string CreatorName,
        string CompanyId
    ) : ICommand<CreateSafeTransactionCommandResponse>;
