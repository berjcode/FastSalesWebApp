using AutoMapper;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Queries.GetCurrency;

public sealed class GetCurrencyQueryHandler : IQueryHandler<GetCurrencyQuery, GetCurrencyQueryResponse>
{
    private readonly ICurrencyService _service;
 


    public GetCurrencyQueryHandler(ICurrencyService service)
    {
        _service = service;
       
    }

    public async Task<GetCurrencyQueryResponse> Handle(GetCurrencyQuery request, CancellationToken cancellationToken)
    {
        var result = await _service.GetCurrency(request.CompanyId, request.id);     
        return result;
    }
}
