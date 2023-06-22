namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetCustomerTransaction;

public sealed record  GetCustomerTransactionQueryResponse(
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
 string CreatorName,
 DateTime? CreatedDate,
 string UpdaterName,
 DateTime? UpdatedDate,
 bool? IsActive
    );

