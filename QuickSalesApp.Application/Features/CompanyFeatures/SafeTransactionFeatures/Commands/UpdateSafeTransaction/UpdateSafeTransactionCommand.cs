using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.UpdateSafeTransaction;

public sealed record UpdateSafeTransactionCommand(
        int Id,    
        string PlugNo,
        string SafeCode,
        DateTime? TransactionDate,
        string Text,
        decimal Debt,
        decimal Credit,
        decimal Remainder,
        int ProcessTypeId,
        string UpdaterName,
        string CompanyId
    ) : ICommand<UpdateSafeTransactionCommandResponse>;