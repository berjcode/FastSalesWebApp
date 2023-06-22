namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetByIdProductUnit;

public sealed record GetByIdProductUnitQueryResponse(

        int Id,
        string ProductCode,
        decimal Factor,
        bool IsDefault,
        string UnitName,
        string CreatorName,
        DateTime? CreatedDate,
        string UpdaterName,
        DateTime? UpdateDate,
        bool? IsActive

    );