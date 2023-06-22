using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetLastCode;

public sealed class GetLastCodeQueryHandler : IQueryHandler<GetLastCodeQuery, GetLastCodeQueryResponse>
{
    private readonly ICustomerService _customerService;

    public GetLastCodeQueryHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<GetLastCodeQueryResponse> Handle(GetLastCodeQuery request, CancellationToken cancellationToken)
    {
        var result = _customerService.GetLastCode(request);
        return new(result);
    }
}
