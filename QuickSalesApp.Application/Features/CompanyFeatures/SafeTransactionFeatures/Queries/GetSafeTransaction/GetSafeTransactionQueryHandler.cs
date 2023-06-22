using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetSafeTransaction;

public sealed class GetSafeTransactionQueryHandler : IQueryHandler<GetSafeTransactionQuery, GetSafeTransactionQueryResponse>
{
    private readonly ISafeTransactionService _transactionService;

    public GetSafeTransactionQueryHandler(ISafeTransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<GetSafeTransactionQueryResponse> Handle(GetSafeTransactionQuery request, CancellationToken cancellationToken)
    {
        var result = await _transactionService.GetSafeTransaction(request.CompanyId, request.Id);
        if (result == null) throw new Exception(ExceptionMessage.NullDataException);
        return result;
    }
}
