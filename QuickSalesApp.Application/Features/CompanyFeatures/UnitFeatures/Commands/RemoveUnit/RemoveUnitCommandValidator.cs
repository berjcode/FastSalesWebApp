using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.RemoveUnit;

public sealed class RemoveUnitCommandValidator : AbstractValidator<RemoveUnitCommand>
{
    public RemoveUnitCommandValidator()
    {
        RuleFor(p => p.id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.id).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
