namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllProductUnit;

public sealed record GetAllProductUnitQueryResponse(
        int Id,
       
        decimal Factor,
        bool IsDefault,
        string UnitName,
        string CreatorName
    );
