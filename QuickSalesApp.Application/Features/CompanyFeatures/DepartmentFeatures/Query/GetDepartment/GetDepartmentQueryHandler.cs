
using AutoMapper;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetAllDepartment;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;


public sealed class GetDepartmentQueryHandler : IQueryHandler<GetDepartmentQuery, GetDepartmentQueryResponse>
{
    private readonly IDepartmentService _departmentService;

    public GetDepartmentQueryHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;

    }

    public async Task<GetDepartmentQueryResponse> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
    {
        var result = await _departmentService.GetDepartment(request.companyId, request.id);
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