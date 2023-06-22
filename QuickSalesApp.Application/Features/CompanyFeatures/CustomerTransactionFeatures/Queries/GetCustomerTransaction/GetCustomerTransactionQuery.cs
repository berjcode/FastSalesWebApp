using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetCustomerTransaction;

public sealed record GetCustomerTransactionQuery(
    string companyId,
   int CustomerTransactionId
    ) :IQuery<GetCustomerTransactionQueryResponse>;
