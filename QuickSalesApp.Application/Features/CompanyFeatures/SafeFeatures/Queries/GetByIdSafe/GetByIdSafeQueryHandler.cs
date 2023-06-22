using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetByIdSafe;

public sealed class GetByIdSafeQueryHandler : IQueryHandler<GetByIdSafeQuery, GetByIdSafeQueryResponse>
{
    private readonly ISafeService _service;

    public GetByIdSafeQueryHandler(ISafeService service)
    {
        _service = service;
    }

    public async Task<GetByIdSafeQueryResponse> Handle(GetByIdSafeQuery request, CancellationToken cancellationToken)
    {
        var result = await _service.GetSafe(request.CompanyId, request.Id);
        if (result == null) throw new Exception(ExceptionMessage.NullDataException);
        return result;
    }
}
