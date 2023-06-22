using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.UpdateCategory;

public sealed class UpdateCategoryCommandValidator :AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Category bilgisi boş olamaz.");
        RuleFor(p => p.Id).NotNull().WithMessage("Category  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
