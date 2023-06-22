namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllFilterUnit;

public sealed record GetAllFilterUnitQueryResponse(
        int Id,
        string Name,
        decimal Factor,
        bool IsDat,
        string CreatorName,
        DateTime? CreatedDate,
        string UpdaterName,
        DateTime? UpdateDate,
        bool? IsActive
    );
