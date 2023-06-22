using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllByFilterProductBarcode;

public sealed class GetAllByFilterProductBarcodeQueryHandler : IQueryHandler<GetAllByFilterProductBarcodeQuery, PaginationResult<GetAllByFilterProductBarcodeQueryResponse>>
{
    private readonly IProductBarcodeService _productBarcodeService;

    public GetAllByFilterProductBarcodeQueryHandler(IProductBarcodeService productBarcodeService)
    {
        _productBarcodeService = productBarcodeService;
    }

    public async Task<PaginationResult<GetAllByFilterProductBarcodeQueryResponse>> Handle(GetAllByFilterProductBarcodeQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<ProductBarcode> result = await _productBarcodeService.GetAllFilter(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _productBarcodeService.GetCountbyFilter(request.CompanyId, request.Expression);
        PaginationResult<GetAllByFilterProductBarcodeQueryResponse> response = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllByFilterProductBarcodeQueryResponse(
                    s.Id,
                    s.Barcode,
                    s.ProductUnitId,
                    s.IsActive                  
                )).ToList());
        return response;
    }
}
