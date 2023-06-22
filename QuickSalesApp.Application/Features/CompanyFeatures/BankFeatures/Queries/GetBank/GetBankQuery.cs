using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetBank;

public sealed  record GetBankQuery(string companyId,
   int id): IQuery<GetBankQueryResponse>;
