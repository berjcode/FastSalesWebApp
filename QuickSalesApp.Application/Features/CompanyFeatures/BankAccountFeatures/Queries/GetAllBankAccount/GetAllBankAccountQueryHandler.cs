using AutoMapper;
using EntityFrameworkCorePagination.Nuget.Pagination;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetAllBank;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetAllBankAccount;

public sealed class GetAllBankAccountQueryHandler : IQueryHandler<GetAllBankAccountQuery, PaginationResult<GetAllBankAccountQueryResponse>>
{
    private readonly IBankAccountService _bankAccountService;
    

    public GetAllBankAccountQueryHandler(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
       
    }

    public async Task<PaginationResult<GetAllBankAccountQueryResponse>> Handle(GetAllBankAccountQuery request, CancellationToken cancellationToken)
    {
        PaginationResult<BankAccount> result = await _bankAccountService.GetAllActive(request.CompanyId, request.PageNumber, request.PageSize);

        int count = _bankAccountService.GetCount(request.CompanyId);
        PaginationResult<GetAllBankAccountQueryResponse> newResult = new(
            pageNumber: request.PageNumber,
            pageSize: request.PageSize,
            totalCount: count,
           datas: result.Datas.Select(s => new GetAllBankAccountQueryResponse(
                s.Id, s.Code, s.Name, s.IBAN, s.AcountNumber, s.CurrencyId, s.CompanyId

                )).ToList());




        return newResult;
    }
}
