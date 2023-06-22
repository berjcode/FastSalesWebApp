using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetTransactionType;

public sealed class GetTransactionTypeQueryHandler : IQueryHandler<GetTransactionTypeQuery, GetTransactionTypeQueryResponse>
{
    private readonly ITransactionTypeService _transactionTypeService;

    public GetTransactionTypeQueryHandler(ITransactionTypeService transactionTypeService)
    {
        _transactionTypeService = transactionTypeService;
    }

    public async Task<GetTransactionTypeQueryResponse> Handle(GetTransactionTypeQuery request, CancellationToken cancellationToken)
    {
        var result = await _transactionTypeService.GetTransactionType(request.CompanyId, request.Id);
        if (result == null) throw new Exception(ExceptionMessage.NullDataException);
        return result;
    }
}
