using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.UpdateProduct;

public sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, UpdateProductCommandResponse>
{
    private readonly IProductService _productService;

    public UpdateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productService.GetByIdAsync(request.Id,request.CompanyId);
        if (product == null) throw new Exception(ExceptionMessage.UpdateNotFoundException);

        Product product2 = await _productService.GetByIdAsync(request.Id, request.CompanyId);
        if (product2 != null && product2.IsActive == true && product2.Id != request.Id && product2.Name == request.Name) throw new Exception("Değiştirmek İstediğiniz Ürün Adı Zaten Kullanımda");

        await _productService.UpdateAsync(request);
        return new();
    }
}
