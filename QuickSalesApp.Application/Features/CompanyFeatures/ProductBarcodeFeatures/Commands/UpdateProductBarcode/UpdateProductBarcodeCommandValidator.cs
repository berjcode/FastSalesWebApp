using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.UpdateProductBarcode
{
    public sealed class UpdateProductBarcodeCommandValidator : AbstractValidator<UpdateProductBarcodeCommand>
    {
        public UpdateProductBarcodeCommandValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("Id Boş Olamaz");
            RuleFor(p => p.Id).NotEmpty().WithMessage("Id Boş Olamaz");
            RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id Boş Olamaz");
            RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id Boş Olamaz");

        }
    }
}
