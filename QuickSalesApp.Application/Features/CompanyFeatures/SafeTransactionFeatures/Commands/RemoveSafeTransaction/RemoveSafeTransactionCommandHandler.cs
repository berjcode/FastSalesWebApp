using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.RemoveSafeTransaction;

public sealed class RemoveSafeTransactionCommandHandler : ICommandHandler<RemoveSafeTransactionCommand, RemoveSafeTransactionCommandResponse>
{
    private readonly ISafeTransactionService _safelyTransactionService;

    public RemoveSafeTransactionCommandHandler(ISafeTransactionService safelyTransactionService)
    {
        _safelyTransactionService = safelyTransactionService;
    }

    public async Task<RemoveSafeTransactionCommandResponse> Handle(RemoveSafeTransactionCommand request, CancellationToken cancellationToken)
    {
        SafeTransaction transaction = await _safelyTransactionService.GetByIdAsync(request.id, request.CompanyId);
        if (transaction == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _safelyTransactionService.RemoveByIdHard(request);
        return new();
    }
}
