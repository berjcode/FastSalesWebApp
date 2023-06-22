using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductCommandResponse>
{
    private readonly IProductService _productService;

    public CreateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request,
        CancellationToken cancellationToken)
    {
        await _productService.CreateAsync(request, cancellationToken);
        return new();
    }
}

