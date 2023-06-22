using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetCustomerType;

public sealed  record GetCustomerTypeQuery(string companyId,
   int id): IQuery<GetCustomerTypeQueryResponse>;
