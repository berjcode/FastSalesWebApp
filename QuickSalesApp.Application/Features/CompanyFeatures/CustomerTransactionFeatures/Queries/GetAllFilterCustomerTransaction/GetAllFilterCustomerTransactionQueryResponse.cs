namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetAllFilterCustomerTransaction;

public sealed record GetAllFilterCustomerTransactionQueryResponse(
 int Id,
 string PlugNo,
 string CustomerCode,
 DateTime? TransactionDate,
 string Text,
 string Description,
 decimal Debt,
 decimal Credit,
 decimal Remainder,
 int ProcessTypeId,
 string TransactionTypeName,
 string CreatorName,
 DateTime? CreatedDate,
 string UpdaterName,
 DateTime? UpdatedDate,
 bool? IsActive);




