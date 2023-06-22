
using AutoMapper;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetAllDepartment;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetBank;


public sealed class GetBankQueryHandler : IQueryHandler<GetBankQuery, GetBankQueryResponse>
{
    private readonly IBankService _bankService;

    public GetBankQueryHandler(IBankService bankService)
    {
        _bankService = bankService;
    }

    public async Task<GetBankQueryResponse> Handle(GetBankQuery request, CancellationToken cancellationToken)
    {
        var result = await _bankService.GetBank(request.companyId, request.id);
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