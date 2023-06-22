using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetBankAccount;

public sealed record GetBankAccountQuery(
    string companyId,
   int BankAccountId

    ) : IQuery<GetBankAccountQueryResponse>;
