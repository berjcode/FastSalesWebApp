using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.RemoveSoftVatType;

public sealed class RemoveSoftVatTypeCommandValidator : AbstractValidator<RemoveSoftVatTypeCommand>
{
    public RemoveSoftVatTypeCommandValidator()
    {
        RuleFor(p => p.id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.id).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
