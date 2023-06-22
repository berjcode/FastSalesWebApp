using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetBankAccount;

public sealed class GetBankAccountQueryHandler : IQueryHandler<GetBankAccountQuery, GetBankAccountQueryResponse>
{

    private readonly IBankAccountService _bankAccountService;

    public GetBankAccountQueryHandler(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public async Task<GetBankAccountQueryResponse> Handle(GetBankAccountQuery request, CancellationToken cancellationToken)
    {
        var result = await _bankAccountService.GetBankAccount(request.companyId, request.BankAccountId);

        return result;
    }
}
