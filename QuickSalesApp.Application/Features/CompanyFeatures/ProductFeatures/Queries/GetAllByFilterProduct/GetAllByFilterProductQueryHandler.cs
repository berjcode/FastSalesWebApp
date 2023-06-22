using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using System.Linq;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllByFilterProduct;

public sealed class GetAllByFilterProductQueryHandler : IQueryHandler<GetAllByFilterProductQuery, PaginationResult<GetAllByFilterProductQueryResponse>>
{
    private readonly IProductService _productService;

    public GetAllByFilterProductQueryHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<PaginationResult<GetAllByFilterProductQueryResponse>> Handle(GetAllByFilterProductQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Product> result = await _productService.GetAllFilter(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _productService.GetCountbyFilter(request.CompanyId, request.Expression);
        PaginationResult<GetAllByFilterProductQueryResponse> response = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllByFilterProductQueryResponse(
                    s.Id,
                    s.Code,
                    s.Name,
                    s.Photo,
                    s.ProductType.Name,
                    s.Category.Name,
                    s.VatType.Name,
                    s.ProductTypeId,
                    s.CategoryId,
                    s.VatTypeId,
                    s.IsActive,
                    s.GroupCode,
                    s.SPECode1,
                    s.SPECode2,
                    s.SPECode3,
                    s.SPECode4,
                    s.SPECode5,
                    s.CreatedDate,
                    s.CreatorName
                )).ToList());
        return response;
    }
}
