using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllActiveUnit;

public sealed class GetAllActiveUnitQueryHandler : IQueryHandler<GetAllActiveUnitQuery, PaginationResult<GetAllActiveUnitQueryResponse>>
{

    private readonly IUnitService _unitService;
    private readonly IMapper _mapper;

    public GetAllActiveUnitQueryHandler(IUnitService unitService, IMapper mapper)
    {
        _unitService = unitService;
        _mapper = mapper;
    }


    public async Task<PaginationResult<GetAllActiveUnitQueryResponse>> Handle(GetAllActiveUnitQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Unit> result = await _unitService.GetAllActive(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _unitService.GetCount(request.CompanyId);
        PaginationResult<GetAllActiveUnitQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => _mapper.Map<GetAllActiveUnitQueryResponse>(s)).ToList()
            );


        return newResult;
    }
}
