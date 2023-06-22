namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllByFilterProductUnit;

public sealed record GetAllByFilterProductUnitQueryResponse(
        int Id,
        decimal Factor,
        bool IsDefault,
        string UnitName,
        int UnitId,
        string CreatorName
    );
