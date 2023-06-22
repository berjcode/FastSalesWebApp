using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllUnit;

public sealed class GetAllUnitQueryHandler : IQueryHandler<GetAllUnitQuery, PaginationResult<GetAllUnitQueryResponse>>
{
    private readonly IUnitService _unitService;
    private readonly IMapper _mapper;

    public GetAllUnitQueryHandler(IUnitService unitService, IMapper mapper)
    {
        _unitService = unitService;
        _mapper = mapper;
    }

    public async Task<PaginationResult<GetAllUnitQueryResponse>> Handle(GetAllUnitQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Unit> result = await _unitService.GetAll(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _unitService.GetCount(request.CompanyId);
        PaginationResult<GetAllUnitQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => _mapper.Map<GetAllUnitQueryResponse>(s)).ToList()
            );


        return newResult;
    }
}
