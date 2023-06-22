using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.RemoveProductTransaction;

public sealed class RemoveProductTransactionCommandHandler : ICommandHandler<RemoveProductTransactionCommand, RemoveProductTransactionCommandResponse>
{
    private readonly IProductTransactionService _productTransactionService;

    public RemoveProductTransactionCommandHandler(IProductTransactionService productTransactionService)
    {
        _productTransactionService = productTransactionService;
    }

    public async Task<RemoveProductTransactionCommandResponse> Handle(RemoveProductTransactionCommand request, CancellationToken cancellationToken)
    {
        ProductTransaction transaction = await _productTransactionService.GetByIdAsync(request.id, request.CompanyId);
        if (transaction == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _productTransactionService.RemoveByIdHard(request);
        return new();
    }
}
