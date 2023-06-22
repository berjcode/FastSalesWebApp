using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.UpdateProduct
{
    public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
            RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");

            //RuleFor(p => p.Id).NotEmpty().WithMessage("Id bilgisi boş olamaz.");
            //RuleFor(p => p.Id).NotNull().WithMessage("Id Bilgisi girilmelidir.");
        }
    }
}
