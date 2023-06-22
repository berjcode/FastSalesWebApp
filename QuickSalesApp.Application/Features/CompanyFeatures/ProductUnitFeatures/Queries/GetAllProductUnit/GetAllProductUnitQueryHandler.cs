using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllProductUnit;

public sealed class GetAllProductUnitQueryHandler : IQueryHandler<GetAllProductUnitQuery, PaginationResult<GetAllProductUnitQueryResponse>>
{
    private readonly IProductUnitService _productUnitService;

    public GetAllProductUnitQueryHandler(IProductUnitService productUnitService)
    {
        _productUnitService = productUnitService;
    }

    public async Task<PaginationResult<GetAllProductUnitQueryResponse>> Handle(GetAllProductUnitQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<ProductUnit> result = await _productUnitService.GetAllActive(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _productUnitService.GetCount(request.CompanyId);
        PaginationResult<GetAllProductUnitQueryResponse> response = new(
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                totalCount: count,
                datas: result.Datas.Select(
                        s => new GetAllProductUnitQueryResponse(
                                s.Id,
                              
                                s.Factor,
                                s.IsDefault,
                                s.Unit.Name,
                                s.CreatorName
                            )).ToList());

        return response;
    }
}
