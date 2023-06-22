using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;


namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Queries.GetAllCurrency;

public sealed class GetAllCurrencyQueryHandler : IQueryHandler<GetAllCurrencyQuery, PaginationResult<GetAllCurrencyQueryResponse>>
{
    private readonly ICurrencyService _service;

    public GetAllCurrencyQueryHandler(ICurrencyService service)
    {
        _service = service;
    }


    public async Task<PaginationResult<GetAllCurrencyQueryResponse>> Handle(GetAllCurrencyQuery request, CancellationToken cancellationToken)
    {

        PaginationResult<Currency> result = await _service.GetAllActive(request.CompanyId, request.PageNumber, request.PageSize);

        int count = _service.GetCount(request.CompanyId);
        PaginationResult<GetAllCurrencyQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
            datas: result.Datas.Select(s => new GetAllCurrencyQueryResponse(

             Id: s.Id, Name: s.Name, CreatorName: s.CreatorName, CreatedDate: s.CreatedDate, UpdaterName: s.UpdaterName, UpdateDate: s.UpdateDate, IsActive: s.IsActive)).ToList());

        return newResult;
    }

    //public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    //{
    //    return new(await _categoryService.GetAllActive(request.CompanyId, request.PageNumber, request.PageSize));
    //}
}
