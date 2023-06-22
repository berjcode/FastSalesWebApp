using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.RemoveSoftProductBarcode;

public sealed class RemoveSoftProductBarcodeCommandValidator : AbstractValidator<RemoveSoftProductBarcodeCommand>
{
    public RemoveSoftProductBarcodeCommandValidator()
    {
        RuleFor(p => p.id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.id).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
