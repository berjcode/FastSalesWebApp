using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetByIdProduct;

public sealed record GetByIdProductQueryResponse(
        string Code,
        string Name,
        string VatTypeName,
        string ProductTypeName,
        string CategoryName,
        DateTime? CreatedDate,
        string UpdaterName,
        DateTime? UpdateDate,
        bool? IsActive
    );
