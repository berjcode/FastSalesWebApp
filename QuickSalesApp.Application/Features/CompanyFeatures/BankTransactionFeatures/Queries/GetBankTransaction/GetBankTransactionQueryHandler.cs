using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Queries.GetBankTransaction;

public sealed class GetBankTransactionQueryHandler : IQueryHandler<GetBankTransactionQuery, GetBankTransactionQueryResponse>
{

    private readonly IBankTransactionService _bankTransactionService;

    public GetBankTransactionQueryHandler(IBankTransactionService bankTransactionService)
    {
        _bankTransactionService = bankTransactionService;
    }

    public async Task<GetBankTransactionQueryResponse> Handle(GetBankTransactionQuery request, CancellationToken cancellationToken)
    {
        var result = await _bankTransactionService.GetBankTransaction(request.CompanyId, request.Id);
        return result;
    }
}
