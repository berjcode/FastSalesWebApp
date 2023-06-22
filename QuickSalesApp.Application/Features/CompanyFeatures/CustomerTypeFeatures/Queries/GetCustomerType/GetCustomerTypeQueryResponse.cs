

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetCustomerType;

public sealed record GetCustomerTypeQueryResponse(
    int Id,
    string Name, 
    string CreatorName,
    DateTime? CreatedDate,
      string UpdaterName,
  DateTime? UpdateDate,
     bool? IsActive
    );
