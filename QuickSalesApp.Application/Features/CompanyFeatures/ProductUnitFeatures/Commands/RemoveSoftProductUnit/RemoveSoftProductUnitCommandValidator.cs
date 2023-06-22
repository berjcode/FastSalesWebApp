using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.RemoveSoftProductUnit;

public sealed class RemoveSoftProductUnitCommandValidator : AbstractValidator<RemoveSoftProductUnitCommand>
{
    public RemoveSoftProductUnitCommandValidator()
    {
        //RuleFor(p => p.Id).NotNull().WithMessage("Id boş olamaz");
        //RuleFor(p => p.Id).NotEmpty().WithMessage("Id boş olamaz");
        //RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        //RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
