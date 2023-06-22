namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllByFilterProduct;

public sealed record GetAllByFilterProductQueryResponse(
        int Id,
        string Code,
        string Name,
        string Photo,
        string ProductTypeName,
        string CategoryName,
        string VatTypeName,
        int ProductTypeId,
        int CategoryId,
        int VatTypeId,
        bool? IsActive,
        string GroupCode,
        int speCode1,
        int speCode2,
        int speCode3,
        int speCode4,
        int speCode5,
        DateTime? CreatedDate,
        string CreatorName
    );
