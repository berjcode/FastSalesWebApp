using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.StateProductUnit;

public sealed class StateProductUnitCommandValidator : AbstractValidator<StateProductUnitCommand>
{
    public StateProductUnitCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id boş olamaz");

        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Id boş olamaz");

        RuleFor(p => p.DeleterName).NotEmpty().WithMessage("DeleterName boş olamaz");
        RuleFor(p => p.DeleterName).NotNull().WithMessage("DeleterName boş olamaz");
    }
}
