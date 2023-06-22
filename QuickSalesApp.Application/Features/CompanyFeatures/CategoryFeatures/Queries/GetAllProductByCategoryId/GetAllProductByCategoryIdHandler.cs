using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos;
using System.Collections.Generic;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllProductByCategoryId;

public sealed class GetAllProductByCategoryIdHandler : IQueryHandler<GetAllProductByCategoryIdQuery, IList<GetAllProductByCategoryIdResponse>>
{
    private readonly ICategoryService _categoryService;

    public GetAllProductByCategoryIdHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IList<GetAllProductByCategoryIdResponse>> Handle(GetAllProductByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _categoryService.GetAllProductByCategory(request.CompanyId, request.Id);



        IList<GetAllProductByCategoryIdResponse> newResult = result.Select(s => new GetAllProductByCategoryIdResponse
        (
            Name: s.Name,
            Id: s.Id,
            Products: s.Products.Select(p => new ProductAndProductUnitDto
            (
                Id: p.Id,
                Name: p.Name,
                Code: p.Code,
                UrlPhoto: p.Photo,
                VatTypeValue: p.VatType.Value,
                ProductUnits: p.ProductUnits.Select( p=> new ProductUnitDto(
                    
                    Price: p.Price,
                    UnitId: p.UnitId,
                    UnitName: p.Unit.Name,
                    isVat:p.IsVat,
                    Amount: p.Amount,
                    Weight: p.Weight
                )).ToList()
                
            )).ToList(),

           ProductCount: s.Products.Count()
        )).ToList();



        return newResult;
    }
}
