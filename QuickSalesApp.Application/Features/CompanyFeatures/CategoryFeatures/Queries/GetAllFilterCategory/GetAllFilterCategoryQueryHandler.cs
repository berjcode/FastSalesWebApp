using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllByFilterProduct;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllFilterCategory;

public sealed class GetAllFilterCategoryQueryHandler : IQueryHandler<GetAllFilterCategoryQuery, PaginationResult<GetAllFilterCategoryQueryResponse>>
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public GetAllFilterCategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    public async Task<PaginationResult<GetAllFilterCategoryQueryResponse>> Handle(GetAllFilterCategoryQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Category> result = await _categoryService.GetAllFilter(request);

        if (result == null || result.Datas == null)
            throw new Exception("Herhangi bir veri bulunamadı");

        int count = _categoryService.GetCountbyFilter(request.CompanyId, request.Expression);
        PaginationResult<GetAllFilterCategoryQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => _mapper.Map<GetAllFilterCategoryQueryResponse>(s)).ToList());


        return newResult;
    }
}
