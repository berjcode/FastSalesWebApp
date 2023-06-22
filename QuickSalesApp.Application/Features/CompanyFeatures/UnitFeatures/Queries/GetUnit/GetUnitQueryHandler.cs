using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetUnit;

public sealed class GetUnitQueryHandler : IQueryHandler<GetUnitQuery, GetUnitQueryResponse>
{
    private readonly IUnitService _unitService;

    public GetUnitQueryHandler(IUnitService unitService)
    {
        _unitService = unitService;
    }

    public async Task<GetUnitQueryResponse> Handle(GetUnitQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitService.GetUnit(request.CompanyId, request.Id);
        if (result == null) throw new Exception(ExceptionMessage.NullDataException);
        return result;
    }
}
