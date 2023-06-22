namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllFilterCategory;

public sealed record GetAllFilterCategoryQueryResponse(
        int Id,
        string Name,
        string Description,
        string CreatorName,
        DateTime? CreatedDate,
        string UpdaterName,
        DateTime? UpdateDate,
        bool? IsActive
    );