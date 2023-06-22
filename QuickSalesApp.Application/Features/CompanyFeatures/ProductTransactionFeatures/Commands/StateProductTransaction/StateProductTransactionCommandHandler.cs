using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.StateProductTransaction;

public sealed class StateProductTransactionCommandHandler : ICommandHandler<StateProductTransactionCommand, StateProductTransactionCommandResponse>
{
    private readonly IProductTransactionService _productTransactionService;

    public StateProductTransactionCommandHandler(IProductTransactionService productTransactionService)
    {
        _productTransactionService = productTransactionService;
    }

    public async Task<StateProductTransactionCommandResponse> Handle(StateProductTransactionCommand request, CancellationToken cancellationToken)
    {
        ProductTransaction transaction = await _productTransactionService.GetByIdAsync(request.Id, request.CompanyId);
        if (transaction == null) throw new Exception(ExceptionMessage.NullDataException);

        transaction.IsActive = request.IsActive;
        transaction.DeleterName = request.DeleterName;
        transaction.DeletedTime = DateTime.Now;

        await _productTransactionService.ChangeState(transaction, request.CompanyId);
        return new();
    }
}
