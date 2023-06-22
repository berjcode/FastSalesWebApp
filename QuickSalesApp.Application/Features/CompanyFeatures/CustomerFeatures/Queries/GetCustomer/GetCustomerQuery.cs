using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetCustomer;

public sealed  record GetCustomerQuery(string companyId,
   int id): IQuery<GetCustomerQueryResponse>;
