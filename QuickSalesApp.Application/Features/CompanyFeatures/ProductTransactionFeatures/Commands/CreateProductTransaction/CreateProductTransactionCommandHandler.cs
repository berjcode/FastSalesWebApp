using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.CreateProductTransaction;

public sealed class CreateProductTransactionCommandHandler : ICommandHandler<CreateProductTransactionCommand, CreateProductTransactionCommandResponse>
{
    private readonly IProductTransactionService _productTransactionService;

    public CreateProductTransactionCommandHandler(IProductTransactionService productTransactionService)
    {
        _productTransactionService = productTransactionService;
    }

    public async Task<CreateProductTransactionCommandResponse> Handle(CreateProductTransactionCommand request, CancellationToken cancellationToken)
    {
        await _productTransactionService.CreateAsync(request, cancellationToken);
        return new();
    }
}
