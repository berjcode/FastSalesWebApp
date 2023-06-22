using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.RemoveSoftUnit;

public sealed class RemoveSoftUnitCommandValidator : AbstractValidator<RemoveSoftUnitCommand>
{
    public RemoveSoftUnitCommandValidator()
    {
        RuleFor(p => p.UnitId).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.UnitId).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
