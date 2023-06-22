using AutoMapper;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetCategory;

public sealed class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, GetCategoryQueryResponse>
{
    private readonly ICategoryService _categoryService;

    public GetCategoryQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
       
    }

    public async Task<GetCategoryQueryResponse> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {

        var result = await _categoryService.GetCategory(request.CompanyId, request.id);

      
        return result;
    }
}
