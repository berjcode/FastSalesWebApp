namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetCategory;

public sealed record GetCategoryQueryResponse(int Id,
    string Name,
    string Description,
     string CreatorName,
    DateTime? CreatedDate,
      string UpdaterName,
  DateTime? UpdateDate,
     bool? IsActive
    );


