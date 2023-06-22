using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllProductByCategoryId;

public sealed record GetAllProductByCategoryIdResponse(
        string Name,
        int Id,
        List<ProductAndProductUnitDto> Products,
        
       int  ProductCount


    );