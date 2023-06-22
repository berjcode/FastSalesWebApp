using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.RemoveSoftProductType;

public sealed class RemoveSoftProductTypeCommandValidator : AbstractValidator<RemoveSoftProductTypeCommand>
{
    public RemoveSoftProductTypeCommandValidator()
    {
        RuleFor(p => p.id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.id).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
