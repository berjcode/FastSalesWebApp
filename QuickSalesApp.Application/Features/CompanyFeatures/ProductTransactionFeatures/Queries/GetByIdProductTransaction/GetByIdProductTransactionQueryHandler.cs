using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetByIdProductTransaction;

public sealed class GetByIdProductTransactionQueryHandler : IQueryHandler<GetByIdProductTransactionQuery, GetByIdProductTransactionQueryResponse>
{
    private readonly IProductTransactionService _productTransactionService;

    public GetByIdProductTransactionQueryHandler(IProductTransactionService productTransactionService)
    {
        _productTransactionService = productTransactionService;
    }

    public async Task<GetByIdProductTransactionQueryResponse> Handle(GetByIdProductTransactionQuery request, CancellationToken cancellationToken)
    {
        var result = await _productTransactionService.GetProductTransaction(request.CompanyId, request.Id);
        if (result == null) throw new Exception(ExceptionMessage.NullDataException);
        return result;
    }
}
