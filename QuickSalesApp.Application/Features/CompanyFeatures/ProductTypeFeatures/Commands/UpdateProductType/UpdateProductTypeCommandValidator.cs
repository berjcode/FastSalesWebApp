using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.UpdateProductType;

public sealed class UpdateProductTypeCommandValidator : AbstractValidator<UpdateProductTypeCommand>
{
    public UpdateProductTypeCommandValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");

        RuleFor(p => p.Id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id boş olamaz");
    }
}
