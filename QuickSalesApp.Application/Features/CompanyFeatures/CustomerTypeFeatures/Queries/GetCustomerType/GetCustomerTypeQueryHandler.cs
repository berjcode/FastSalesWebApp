
using AutoMapper;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetAllDepartment;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetCustomerType;


public sealed class GetCustomerTypeQueryHandler : IQueryHandler<GetCustomerTypeQuery, GetCustomerTypeQueryResponse>
{
   private readonly ICustomerTypeService _customerTypeService;

    public GetCustomerTypeQueryHandler(ICustomerTypeService customerTypeService)
    {
        _customerTypeService = customerTypeService;
    }

    public async Task<GetCustomerTypeQueryResponse> Handle(GetCustomerTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await _customerTypeService.GetDepartment(request.companyId, request.id);
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