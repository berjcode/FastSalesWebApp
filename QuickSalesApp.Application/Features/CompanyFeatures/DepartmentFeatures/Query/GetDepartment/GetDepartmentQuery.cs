using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;

public sealed  record GetDepartmentQuery(string companyId,
   int id): IQuery<GetDepartmentQueryResponse>;
