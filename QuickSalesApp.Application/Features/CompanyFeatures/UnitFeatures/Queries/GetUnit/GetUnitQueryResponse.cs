namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetUnit;

public sealed record GetUnitQueryResponse(
        int Id,
        string Name,
        int Factor,
        bool IsDat,
        string CreatorName,
        DateTime? CreatedDate,
        string UpdaterName,
        DateTime? UpdateDate,
        bool? IsActive
    );
