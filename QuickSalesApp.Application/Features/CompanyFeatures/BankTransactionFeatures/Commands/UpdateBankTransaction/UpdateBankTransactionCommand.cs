using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.UpdateBankTransaction;

public sealed record UpdateBankTransactionCommand(
    string CompanyId,
    int BankTransactionId,
 string PlugNo,
 string BankCode,
 DateTime TransactionDate,
 string Text,
 decimal Debt,
 decimal Credit,
 decimal Remainder,
 int ProcessTypeId,
string UpdaterName
    ) :ICommand<UpdateBankTransactionCommandResponse>;
