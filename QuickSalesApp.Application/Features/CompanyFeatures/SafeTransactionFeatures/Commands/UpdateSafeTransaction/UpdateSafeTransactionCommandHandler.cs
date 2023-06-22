using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.UpdateSafeTransaction;

public sealed class UpdateSafeTransactionCommandHandler : ICommandHandler<UpdateSafeTransactionCommand, UpdateSafeTransactionCommandResponse>
{
    private readonly ISafeTransactionService _safeTransactionService;

    public UpdateSafeTransactionCommandHandler(ISafeTransactionService safeTransactionService)
    {
        _safeTransactionService = safeTransactionService;
    }

    public async Task<UpdateSafeTransactionCommandResponse> Handle(UpdateSafeTransactionCommand request, CancellationToken cancellationToken)
    {
        SafeTransaction transaction = await _safeTransactionService.GetByIdAsync(request.Id, request.CompanyId);
        if (transaction == null) throw new Exception(ExceptionMessage.UpdateNotFoundException);

        await _safeTransactionService.UpdateAsync(request);
        return new();
    }
}
