using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.RemoveSoftProduct;

public sealed class RemoveSoftProductCommandHandler : ICommandHandler<RemoveSoftProductCommand, RemoveSoftProductCommandResponse>
{
    private readonly IProductService _productService;

    public RemoveSoftProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<RemoveSoftProductCommandResponse> Handle(RemoveSoftProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productService.GetByIdAsync(request.id, request.CompanyId);
        if (product == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        product.IsDelete = request.IsDelete;
        product.DeleterName = request.DeleterName;
        product.DeletedTime = DateTime.Now;
        product.IsActive = false;

        await _productService.RemoveByIdSoft(request.CompanyId, product);
        return new();
    }
}
