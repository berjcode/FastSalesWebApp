using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetWithUnactive;

public sealed class GetWithUnactiveHandler : IQueryHandler<GetWithUnactiveQuery, PaginationResult<GetWithUnactiveResponse>>
{
    private readonly ICategoryService _categoryService;

    public GetWithUnactiveHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<PaginationResult<GetWithUnactiveResponse>> Handle(GetWithUnactiveQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Category> result = await _categoryService.GetWithUnactive(request.CompanyId, request.PageNumber, request.PageSize);

        int count = _categoryService.GetCount(request.CompanyId);
        PaginationResult<GetWithUnactiveResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetWithUnactiveResponse(
                s.Id,
                s.Name,

                s.Description,
                s.CreatorName,
                s.CreatedDate.ToString(),
                s.UpdaterName,
                s.UpdateDate.ToString(),
                s.IsActive,

                Products: s.Products.Select(p => new ProductDto(
            Id: p.Id,
            Name: p.Name,
           
               Code: p.Code
             )).ToList()
        )).ToList());

        return newResult;
    }
}
