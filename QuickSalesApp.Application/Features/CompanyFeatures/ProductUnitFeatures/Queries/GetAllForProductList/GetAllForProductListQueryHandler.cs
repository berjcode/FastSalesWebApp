using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllForProductList;

public sealed class GetAllForProductListQueryHandler : IQueryHandler<GetAllForProductListQuery, PaginationResult<GetAllForProductListQueryResponse>>
{
    private readonly IProductUnitService _productUnitService;

    public GetAllForProductListQueryHandler(IProductUnitService productUnitService)
    {
        _productUnitService = productUnitService;
    }

    public async Task<PaginationResult<GetAllForProductListQueryResponse>> Handle(GetAllForProductListQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<ProductUnit> result = await _productUnitService.GetAllFilterForProduct(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _productUnitService.GetCountbyFilter(request.CompanyId, request.Expression, request.search);
        PaginationResult<GetAllForProductListQueryResponse> response = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllForProductListQueryResponse(
                    ProductUnitId: s.Id,
                    ProductId: s.ProductId,
                    ProductName: s.Product != null ? s.Product.Name : "",
                    ProductCode: s.Product != null ? s.Product.Code : "",
                    Price: s.Price,
                    IsActive: s.Product.IsActive,
                    Barcode: s.ProductBarcode != null ? s.ProductBarcode.Barcode : "",
                    BarcodeId: s.ProductBarcode != null ? s.ProductBarcode.Id : 0,
                    Photo: s.Product.Photo,
                    Factor: s.Factor,
                    CreatedDate: s.Product.CreatedDate,
                    CreatorName: s.Product.CreatorName,
                    UnitName: s.Unit.Name != null ? s.Unit.Name : "",
                    UnitId: s.UnitId,
                    CategoryId: s.Product.CategoryId,
                    VatTypeId: s.Product.VatTypeId,
                    VatTypeValue: s.Product.VatType.Value,
                    VatTypeName: s.Product.VatType.Name,
                    ProductTypeId: s.Product.ProductTypeId,
                    GroupCode: s.Product.GroupCode,
                    speCode1: s.Product.SPECode1,
                    speCode2: s.Product.SPECode2,
                    speCode3: s.Product.SPECode3,
                    speCode4: s.Product.SPECode4,
                    speCode5: s.Product.SPECode5,
                    IsDefault: s.IsDefault,
                    IsVat: s.IsVat,
                    Amount: s.Amount, TotalProduct: count
                )).ToList());
        return response;
    }
}
