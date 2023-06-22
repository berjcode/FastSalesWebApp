using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Queries.GetBankTransaction;

public sealed record GetBankTransactionQuery(int Id, string CompanyId) : IQuery<GetBankTransactionQueryResponse>;

