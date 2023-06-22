using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.CreateProductType;

public sealed class CreateProductTypeCommandHandler : ICommandHandler<CreateProductTypeCommand, CreateProductTypeCommandResponse>
{

    private readonly IProductTypeService _productTypeService;

    public CreateProductTypeCommandHandler(IProductTypeService productTypeService)
    {
        _productTypeService = productTypeService;
    }

    public async Task<CreateProductTypeCommandResponse> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
    {
        ProductType type = await _productTypeService.GetByNameAsync(request.Name, request.CompanyId);
        if (type != null) throw new Exception("Eklemek Istediğiniz Stok Türü Zaten Ekli");

        await _productTypeService.CreateAsync(request, cancellationToken);
        return new();
    }
}
