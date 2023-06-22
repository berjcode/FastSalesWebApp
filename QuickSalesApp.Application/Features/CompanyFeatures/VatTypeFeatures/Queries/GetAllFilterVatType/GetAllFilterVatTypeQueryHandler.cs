using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllFilterUnit;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllFilterVatType;

public sealed class GetAllFilterVatTypeQueryHandler : IQueryHandler<GetAllFilterVatTypeQuery, PaginationResult<GetAllFilterVatTypeQueryResponse>>
{
    private readonly IVatTypeService _vatTypeService;
    private readonly IMapper _mapper;

    public GetAllFilterVatTypeQueryHandler(IMapper mapper, IVatTypeService vatTypeService)
    {
        _mapper = mapper;
        _vatTypeService = vatTypeService;
    }

    public async Task<PaginationResult<GetAllFilterVatTypeQueryResponse>> Handle(GetAllFilterVatTypeQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<VatType> result = await _vatTypeService.GetAllFilter(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _vatTypeService.GetCountbyFilter(request.CompanyId ,request.Expression);
        PaginationResult<GetAllFilterVatTypeQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => _mapper.Map<GetAllFilterVatTypeQueryResponse>(s)).ToList());
        return newResult;
    }
}
