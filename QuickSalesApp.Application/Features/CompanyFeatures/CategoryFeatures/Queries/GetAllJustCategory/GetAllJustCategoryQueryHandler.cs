using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllJustCategory;

public sealed class GetAllJustCategoryQueryHandler : IQueryHandler<GetAllJustCategoryQuery, IList<GetAllJustCategoryQueryResponse>>
{
    private readonly ICategoryService _categoryService;

    public GetAllJustCategoryQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IList<GetAllJustCategoryQueryResponse>> Handle(GetAllJustCategoryQuery request, CancellationToken cancellationToken)
    {

        var result = await _categoryService.GetAllJustCategory(request.CompanyId);

        var newResult = new List<GetAllJustCategoryQueryResponse>();
        foreach (var item in result)
        {
            int productCount=  _categoryService.GetProductCountByCategoryId(request.CompanyId,item.Id);
            var queryResponse = new GetAllJustCategoryQueryResponse(
                Id: item.Id,
                Name: item.Name,
                  ProductCount: productCount);
            newResult.Add(queryResponse);
        }
        return newResult;

    }

    //public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    //{
    //    return new(await _categoryService.GetAllActive(request.CompanyId, request.PageNumber, request.PageSize));
    //}
}
