using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.UpdateSafe;

public sealed class UpdateSafeCommandValidator : AbstractValidator<UpdateSafeCommand>
{
    public UpdateSafeCommandValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");

        RuleFor(p => p.Id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id boş olamaz");
    }
}
