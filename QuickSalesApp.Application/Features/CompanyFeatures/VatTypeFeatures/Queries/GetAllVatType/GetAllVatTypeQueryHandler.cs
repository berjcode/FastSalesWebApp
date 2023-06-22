using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllVatType;

public sealed class GetAllVatTypeQueryHandler : IQueryHandler<GetAllVatTypeQuery, PaginationResult<GetAllVatTypeQueryResponse>>
{
    private readonly IVatTypeService _vatTypeService;
    private readonly IMapper _mapper;

    public GetAllVatTypeQueryHandler(IVatTypeService vatTypeService, IMapper mapper)
    {
        _vatTypeService = vatTypeService;
        _mapper = mapper;
    }

    public async Task<PaginationResult<GetAllVatTypeQueryResponse>> Handle(GetAllVatTypeQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<VatType> result = await _vatTypeService.GetAll(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _vatTypeService.GetCount(request.CompanyId);
        PaginationResult<GetAllVatTypeQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => _mapper.Map<GetAllVatTypeQueryResponse>(s)).ToList()
            );


        return newResult;
    }
}
