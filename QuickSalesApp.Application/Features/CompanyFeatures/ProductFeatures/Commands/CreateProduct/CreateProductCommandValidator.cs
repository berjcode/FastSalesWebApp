using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct
{
    public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Code).NotNull().WithMessage("Code Bilgisi girilmelidir.");
            RuleFor(p => p.Code).NotEmpty().MinimumLength(3).WithMessage("Code  en az 3 karakter olmalıdır.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name Bilgisi girilmelidir.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Name Bilgisi girilmelidir.");
            RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
            RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
        }
    }
}
