using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetVatType;

public sealed class GetVatTypeQueryHandler : IQueryHandler<GetVatTypeQuery, GetVatTypeQueryResponse>
{
    private readonly IVatTypeService _vatTypeService;

    public GetVatTypeQueryHandler(IVatTypeService vatTypeService)
    {
        _vatTypeService = vatTypeService;
    }

    public async Task<GetVatTypeQueryResponse> Handle(GetVatTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await _vatTypeService.GetVatType(request.CompanyId, request.Id);

        if (result == null) throw new Exception(ExceptionMessage.NullDataException);

        return result;
    }
}
