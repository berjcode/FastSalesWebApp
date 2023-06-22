using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetByIdProductType;

public sealed record GetByIdProductTypeQueryResponse(
        string Name,
        DateTime? CreatedDate,
        string UpdaterName,
        DateTime? UpdateDate,
        bool? IsActive
    );
