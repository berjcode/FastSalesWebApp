using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.RemoveProductBarcode;

public sealed class RemoveProductBarcodeCommandValidator : AbstractValidator<RemoveProductBarcodeCommand>
{
    public RemoveProductBarcodeCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
