using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllByFilterProductUnit;

public sealed class GetAllByFilterProductUnitQueryHandler : IQueryHandler<GetAllByFilterProductUnitQuery, PaginationResult<GetAllByFilterProductUnitQueryResponse>>
{
    private readonly IProductUnitService _productUnitService;

    public GetAllByFilterProductUnitQueryHandler(IProductUnitService productUnitService)
    {
        _productUnitService = productUnitService;
    }

    public async Task<PaginationResult<GetAllByFilterProductUnitQueryResponse>> Handle(GetAllByFilterProductUnitQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<ProductUnit> result = await _productUnitService.GetAllFilter(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _productUnitService.GetCountbyFilter(request.CompanyId, request.Expression,request.search);
        PaginationResult<GetAllByFilterProductUnitQueryResponse> response = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllByFilterProductUnitQueryResponse(
                    s.Id,
                   
                    s.Factor,
                    s.IsDefault,
                    s.Unit.Name,
                    s.UnitId,
                    s.CreatorName
                )).ToList());
        return response;
    }
}
