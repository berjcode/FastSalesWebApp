using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllProductBarcode
{
    public sealed class GetAllProductBarcodeQueryHandler : IQueryHandler<GetAllProductBarcodeQuery, PaginationResult<GetAllProductBarcodeQueryResponse>>
    {
        private readonly IProductBarcodeService _productBarcodeService;

        public GetAllProductBarcodeQueryHandler(IProductBarcodeService productBarcodeService)
        {
            _productBarcodeService = productBarcodeService;
        }

        public async Task<PaginationResult<GetAllProductBarcodeQueryResponse>> Handle(GetAllProductBarcodeQuery request, CancellationToken cancellationToken)
        {

            PaginationResult<ProductBarcode> result = await _productBarcodeService.GetAllActive(request);

            if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

            int count = _productBarcodeService.GetCount(request.CompanyId);
            PaginationResult<GetAllProductBarcodeQueryResponse> response = new(
                    pageNumber: request.PageNumber,
                    pageSize: request.PageSize,
                    totalCount: count,
                    datas: result.Datas.Select(s => new GetAllProductBarcodeQueryResponse(
                            s.Id,
                            s.Barcode,
                            s.ProductUnitId,
                            s.IsActive
                         
                        )).ToList());
            return response;
        }
    }
}
