using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetSafeTransaction;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Queries.GetBankTransaction;

public sealed record GetBankTransactionQueryResponse(
    int Id,
 string PlugNo,
 string BankCode,
 DateTime TransactionDate,
 string Text,
 decimal Debt,
 decimal Credit,
 decimal Remainder,
 int ProcessTypeId,
 string CompanyId,
 string CreatorName,
  DateTime? CreatedDate,
  string UpdaterName,
  DateTime? UpdateDate,
  bool? IsActive

    );

