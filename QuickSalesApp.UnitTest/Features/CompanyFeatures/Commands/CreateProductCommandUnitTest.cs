using Moq;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
using Shouldly;

namespace QuickSalesApp.UnitTest.Features.CompanyFeatures.Commands;

public class CreateProductCommandUnitTest
{
    private readonly Mock<IProductService> _productService;
    public CreateProductCommandUnitTest()
    {
        _productService = new();
    }

    [Fact]
    public async Task ProductShouldBeNull()
    {
        Product product = await _productService.Object.GetByCodeAsync("22","asads");
        product.ShouldBeNull();
    }


   
}

