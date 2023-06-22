using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetCategory;

public sealed  record GetCategoryQuery(
    string CompanyId,
    int id): IQuery<GetCategoryQueryResponse>;

