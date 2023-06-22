using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllActiveVatType;

public sealed class GetAllActiveVatTypeQueryHandler : IQueryHandler<GetAllActiveVatTypeQuery, PaginationResult<GetAllActiveVatTypeQueryResponse>>
{
    private readonly IVatTypeService _vatTypeService;
    private readonly IMapper _mapper;

    public GetAllActiveVatTypeQueryHandler(IVatTypeService vatTypeService, IMapper mapper)
    {
        _vatTypeService = vatTypeService;
        _mapper = mapper;
    }

    public async Task<PaginationResult<GetAllActiveVatTypeQueryResponse>> Handle(GetAllActiveVatTypeQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<VatType> result = await _vatTypeService.GetAllActive(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _vatTypeService.GetCount(request.CompanyId);
        PaginationResult<GetAllActiveVatTypeQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => _mapper.Map<GetAllActiveVatTypeQueryResponse>(s)).ToList()
            );


        return newResult;
    }
}
