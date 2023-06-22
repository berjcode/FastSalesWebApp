using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.StateSafeTransaction;

public sealed class StateSafeTransactionCommandHandler : ICommandHandler<StateSafeTransactionCommand, StateSafeTransactionCommandResponse>
{
    private readonly ISafeTransactionService _transactionService;

    public StateSafeTransactionCommandHandler(ISafeTransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<StateSafeTransactionCommandResponse> Handle(StateSafeTransactionCommand request, CancellationToken cancellationToken)
    {
        SafeTransaction transaction = await _transactionService.GetByIdAsync(request.Id, request.CompanyId);
        if (transaction == null) throw new Exception(ExceptionMessage.NullDataException);

        transaction.IsActive = request.IsActive;
        transaction.DeleterName = request.DeleterName;
        transaction.DeletedTime = DateTime.Now;

        await _transactionService.ChangeState(transaction, request.CompanyId);
        return new();
    }
}
