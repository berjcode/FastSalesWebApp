using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllFilterUnit;

public sealed class GetAllFilterUnitQueryHandler : IQueryHandler<GetAllFilterUnitQuery, PaginationResult<GetAllFilterUnitQueryResponse>>
{
    private readonly IUnitService _unitService;
    private readonly IMapper _mapper;

    public GetAllFilterUnitQueryHandler(IUnitService unitService, IMapper mapper)
    {
        _unitService = unitService;
        _mapper = mapper;
    }

    public async Task<PaginationResult<GetAllFilterUnitQueryResponse>> Handle(GetAllFilterUnitQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Unit> result = await _unitService.GetAllFilter(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _unitService.GetCountbyFilter(request.CompanyId, request.Expression);
        PaginationResult<GetAllFilterUnitQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => _mapper.Map<GetAllFilterUnitQueryResponse>(s)).ToList());
        return newResult;
    }
}
