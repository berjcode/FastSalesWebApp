using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetWithUnactive;

public sealed record GetWithUnactiveResponse(
        int Id,
        string Name,
   
        string Description,
        string CreatorName,
        string CreatedDate,
        string UpdaterName,
        string UpdateDate,
        bool? IsActive,
        List<ProductDto> Products
    );