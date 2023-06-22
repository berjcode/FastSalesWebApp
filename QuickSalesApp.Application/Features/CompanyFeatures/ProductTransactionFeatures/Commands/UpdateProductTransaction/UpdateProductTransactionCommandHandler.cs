using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.UpdateProductTransaction;

public sealed class UpdateProductTransactionCommandHandler : ICommandHandler<UpdateProductTransactionCommand, UpdateProductTransactionCommandResponse>
{
    private readonly IProductTransactionService _productTransactionService;

    public UpdateProductTransactionCommandHandler(IProductTransactionService productTransactionService)
    {
        _productTransactionService = productTransactionService;
    }

    public async Task<UpdateProductTransactionCommandResponse> Handle(UpdateProductTransactionCommand request, CancellationToken cancellationToken)
    {
        ProductTransaction transaction = await _productTransactionService.GetByIdAsync(request.Id, request.CompanyId);
        if (transaction == null) throw new Exception(ExceptionMessage.UpdateNotFoundException);

        await _productTransactionService.UpdateAsync(request);
        return new();
    }
}
