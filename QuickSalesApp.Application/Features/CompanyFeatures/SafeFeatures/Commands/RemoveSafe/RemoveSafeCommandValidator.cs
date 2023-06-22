using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.RemoveSafe;

public sealed class RemoveSafeCommandValidator :AbstractValidator<RemoveSafeCommand>
{
    public RemoveSafeCommandValidator()
    {
        RuleFor(p => p.id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.id).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
