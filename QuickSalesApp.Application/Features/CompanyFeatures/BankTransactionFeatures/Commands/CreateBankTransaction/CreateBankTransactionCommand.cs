using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.CreateBankTransaction;

public sealed record CreateBankTransactionCommand(
 string CompanyId,
 string PlugNo,
 string BankCode,
 DateTime TransactionDate,
 string Text,
 decimal Debt,
 decimal Credit,
 decimal Remainder,
 int ProcessTypeId,
string CreatorName) :ICommand<CreateBankTransactionCommandResponse>;




