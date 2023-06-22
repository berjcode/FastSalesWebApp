using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.RemoveSoftProductTransaction;

public sealed class RemoveSoftProductTransactionCommandHandler : ICommandHandler<RemoveSoftProductTransactionCommand, RemoveSoftProductTransactionCommandResponse>
{
    private readonly IProductTransactionService _transactionService;

    public RemoveSoftProductTransactionCommandHandler(IProductTransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<RemoveSoftProductTransactionCommandResponse> Handle(RemoveSoftProductTransactionCommand request, CancellationToken cancellationToken)
    {
        ProductTransaction transaction = await _transactionService.GetByIdAsync(request.id, request.CompanyId);
        if (transaction == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        transaction.IsDelete = request.IsDelete;
        transaction.DeleterName = request.DeleterName;
        transaction.DeletedTime = DateTime.Now;
        transaction.IsActive = false;

        await _transactionService.RemoveByIdSoft(request.CompanyId, transaction);
        return new();
    }
}
