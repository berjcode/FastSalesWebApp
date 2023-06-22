using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.CreateProductBarcode;

public sealed class CreateProductBarcodeCommandValidator : AbstractValidator<CreateProductBarcodeCommand>
{
    public CreateProductBarcodeCommandValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id Boş Olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id Boş Olamaz");

        RuleFor(p => p.ProductUnitId).NotNull().WithMessage("Ürün Birim Id Boş Olamaz");
        RuleFor(p => p.ProductUnitId).NotEmpty().WithMessage("Ürün Birim Id Boş Olamaz");

        RuleFor(p => p.Barcode).NotNull().WithMessage("Barkod Boş Olamaz");
        RuleFor(p => p.Barcode).NotEmpty().WithMessage("Barkod Boş Olamaz");
    }
}
