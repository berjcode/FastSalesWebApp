using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetAllSafe;

public sealed class GetAllSafeQueryHandler : IQueryHandler<GetAllSafeQuery, PaginationResult<GetAllSafeQueryResponse>>
{
    private readonly ISafeService _safService;

    public GetAllSafeQueryHandler(ISafeService safService)
    {
        _safService = safService;
    }

    public async Task<PaginationResult<GetAllSafeQueryResponse>> Handle(GetAllSafeQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<Safe> result = await _safService.GetAllActive(request);

        if (result == null || result.Datas == null) throw new Exception(ExceptionMessage.NullDataException);

        int count = _safService.GetCount(request.CompanyId);
        PaginationResult<GetAllSafeQueryResponse> response = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllSafeQueryResponse(
                    s.Id,
                    s.Code,
                    s.Name,
                    s.Currency.Name,
                    s.Credit,
                    s.Debt,
                    s.Remainder,
                    s.CompanyId
                )).ToList());
        return response;
    }
}

