namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllUnit;

public sealed record GetAllUnitQueryResponse(
        int Id,
        string Name,
        int Factor,
        bool IsDat,
        string CreatorName,
        string CreatedDate,
        string UpdaterName,
        string UpdateDate,
        bool IsActive
    );
