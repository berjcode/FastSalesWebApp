using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetAllProductType;

public sealed class GetAllProductTypeQueryHandler : IQueryHandler<GetAllProductTypeQuery, PaginationResult<GetAllProductTypeQueryResponse>>
{
    private readonly IProductTypeService _productTypeService;
    private readonly IMapper _mapper;

    public GetAllProductTypeQueryHandler(IProductTypeService productTypeService, IMapper mapper)
    {
        _productTypeService = productTypeService;
        _mapper = mapper;
    }

    public async Task<PaginationResult<GetAllProductTypeQueryResponse>> Handle(GetAllProductTypeQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<ProductType> result = await _productTypeService.GetAllActive(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _productTypeService.GetCount(request.CompanyId);
        PaginationResult<GetAllProductTypeQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => _mapper.Map<GetAllProductTypeQueryResponse>(s)).ToList()
            );


        return newResult;
    }
}
