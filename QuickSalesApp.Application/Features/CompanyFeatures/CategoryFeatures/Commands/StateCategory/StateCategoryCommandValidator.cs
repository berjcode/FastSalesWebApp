using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.StateCategory;

public sealed class StateCategoryCommandValidator :AbstractValidator<StateCategoryCommand>
{
	public StateCategoryCommandValidator()
    {
        RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Category bilgisi boş olamaz.");
        RuleFor(p => p.CategoryId).NotNull().WithMessage("Category  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
