namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllActiveUnit;

public sealed record GetAllActiveUnitQueryResponse(
        int Id,
        string Name,
        int Factor,
        bool IsDat,
        bool IsActive,
        string CreatorName
    );