using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.CreateSafe;

public sealed class CreateSafeCommandValidator : AbstractValidator<CreateSafeCommand>
{
    public CreateSafeCommandValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
