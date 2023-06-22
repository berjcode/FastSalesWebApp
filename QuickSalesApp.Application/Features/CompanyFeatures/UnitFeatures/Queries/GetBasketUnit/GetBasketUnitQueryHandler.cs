using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using QuickSalesApp.Domain.Dtos.SalesBasketDtoClient;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetBasketUnit;

public sealed class GetBasketUnitQueryHandler : IQueryHandler<GetBasketUnitQuery, GetBasketUnitQueryResponse>
{

    private readonly IUnitService _unitService;
    private readonly IMapper _mapper;

    public GetBasketUnitQueryHandler(IUnitService unitService, IMapper mapper)
    {
        _unitService = unitService;
        _mapper = mapper;
    }


    public async Task<GetBasketUnitQueryResponse> Handle(GetBasketUnitQuery request, CancellationToken cancellationToken)
    {
        var  result = await _unitService.GetBasketUnit(request);

        if (result == null || result == null) throw new Exception(ExceptionMessage.NullDataException);


        var unitsDto = _mapper.Map<IList<UnitListDto>>(result);

        var response = new GetBasketUnitQueryResponse(unitsDto);

        return response;
    }
}
