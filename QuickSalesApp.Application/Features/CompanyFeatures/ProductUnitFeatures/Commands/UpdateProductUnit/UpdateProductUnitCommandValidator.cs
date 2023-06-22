using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.UpdateProductUnit;

public sealed class UpdateProductUnitCommandValidator : AbstractValidator<UpdateProductUnitCommand>
{
    public UpdateProductUnitCommandValidator()
    {
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");

        RuleFor(p => p.Id).NotEmpty().WithMessage("Id bilgisi boş olamaz.");
        RuleFor(p => p.Id).NotNull().WithMessage("Id Bilgisi girilmelidir.");
    }
}
