using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.StateBankTransaction;

public sealed record  StateBankTransactionCommand(
        int BankTransactionId,
        string CompanyId,
        bool IsActive,
        string UpdaterName
    ) :ICommand<StateBankTransactionCommandResponse>;
