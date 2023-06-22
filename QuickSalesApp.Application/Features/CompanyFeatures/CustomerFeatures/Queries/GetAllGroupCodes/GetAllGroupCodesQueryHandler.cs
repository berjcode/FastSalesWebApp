using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllGroupCodes;

public sealed class GetAllGroupCodesQueryHandler : IQueryHandler<GetAllGroupCodesQuery, GetAllGroupCodesQueryResponse>
{
    private readonly ICustomerService _customerService;

    public GetAllGroupCodesQueryHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<GetAllGroupCodesQueryResponse> Handle(GetAllGroupCodesQuery request, CancellationToken cancellationToken)
    {
        var result = await _customerService.GetGroupCodes(request);

        return result;
    }
}
