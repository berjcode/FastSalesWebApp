using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos;
using System.Linq;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllCategory;

public sealed class GetAllCategoryQueryHandler : IQueryHandler<GetAllCategoryQuery, PaginationResult<GetAllCategoryQueryResponse>>
{
    private readonly ICategoryService _categoryService;

    public GetAllCategoryQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<PaginationResult<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {

        PaginationResult<Category> result = await _categoryService.GetAllActive(request.CompanyId, request.PageNumber, request.PageSize);

        int count = _categoryService.GetCount(request.CompanyId);
        PaginationResult<GetAllCategoryQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllCategoryQueryResponse(

                Id: s.Id, Name:
                s.Name,
                Description: s.Description,
                CreatorName: s.CreatorName,
                CreatedDate: s.CreatedDate,
                UpdaterName: s.UpdaterName,
                UpdateDate: s.UpdateDate,
                IsActive: s.IsActive,
                 Products: s.Products.Select(p => new ProductDto(
            Id: p.Id,
            Name: p.Name,
            Code: p.Code
          
            )).ToList()
        )).ToList()); ;

        return newResult;
    }

    //public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    //{
    //    return new(await _categoryService.GetAllActive(request.CompanyId, request.PageNumber, request.PageSize));
    //}
}
