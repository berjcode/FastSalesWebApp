using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.RemoveSoftSafeTransaction;

public sealed class RemoveSoftSafeTransactionCommandHandler : ICommandHandler<RemoveSoftSafeTransactionCommand, RemoveSoftSafeTransactionCommandResponse>
{
    private readonly ISafeTransactionService _transactionService;

    public RemoveSoftSafeTransactionCommandHandler(ISafeTransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    public async Task<RemoveSoftSafeTransactionCommandResponse> Handle(RemoveSoftSafeTransactionCommand request, CancellationToken cancellationToken)
    {
        SafeTransaction transaction = await _transactionService.GetByIdAsync(request.Id, request.CompanyId);
        if (transaction == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _transactionService.RemoveByIdSoft(request.CompanyId, request.Id);
        return new();
    }
}
