namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Queries.GetAllBankTransaction;

public sealed record GetAllBankTransactionQueryResponse(
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
  bool? IsActive);





