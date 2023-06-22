using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllProduct;

public class GetAllProductQueryHandler : IQueryHandler<GetAllProductQuery, PaginationResult<GetAllProductQueryResponse>>
{
    private readonly IProductService _productService;

    public GetAllProductQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<PaginationResult<GetAllProductQueryResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Product> result = await _productService.GetAllActive(request.CompanyId,request.PageNumber,request.PageSize);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _productService.GetCount(request.CompanyId);
        PaginationResult<GetAllProductQueryResponse> response = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllProductQueryResponse(
                    s.Id,
                    s.Code,
                    s.Name,
                    s.Photo,
                    s.ProductType.Name,
                    s.Category.Name,
                    s.VatType.Name,
                    s.IsActive,
                    s.GroupCode,
                    s.SPECode1,
                    s.SPECode2,
                    s.SPECode3,
                    s.SPECode4,
                    s.SPECode5
                )).ToList());
        return response;
    }
}
