namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllProduct;

public sealed record GetAllProductQueryResponse(
        int Id,
        string Code,
        string Name,
        string Photo,
        string ProductTypeName,
        string CategoryName,
        string VatTypeName,
        bool? IsActive,
        string GroupCode,
        int speCode1,
        int speCode2,
        int speCode3,
        int speCode4,
        int speCode5
    );
