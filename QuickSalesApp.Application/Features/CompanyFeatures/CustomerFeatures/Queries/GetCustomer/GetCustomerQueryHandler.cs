using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetCustomer;


public sealed class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, GetCustomerQueryResponse>
{
   private readonly ICustomerService _customerService;

    public GetCustomerQueryHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<GetCustomerQueryResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var result = await _customerService.GetCustomer(request.companyId, request.id);
     
        return result;
    }
}
//var queryResponse = new GetDepartmentQueryResponse(
//    Id:result.Id,
//    Name: result.Name,
//    CreatorName: result.CreatorName,
//    CreatedDate: result.CreatedDate,
//    UpdaterName : result.UpdaterName,
//    UpdateDate: result.UpdateDate,
//    IsActive: result.IsActive);