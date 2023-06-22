using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.RemoveProduct;

public sealed class RemoveProductCommandHandler : ICommandHandler<RemoveProductCommand, RemoveProductCommandResponse>
{

    private readonly IProductService _productService;

    public RemoveProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productService.GetByIdAsync(request.Id,request.CompanyId);
        if (product == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _productService.RemoveByIdHard(request.Id, request.CompanyId);
        return new();
    }
}
