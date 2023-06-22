using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.DeleteCategory;

public sealed class DeleteCategoryCommandValidator :AbstractValidator<DeleteCategoryCommand>
{
	public DeleteCategoryCommandValidator()
	{
        RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Category bilgisi boş olamaz.");
        RuleFor(p => p.CategoryId).NotNull().WithMessage("Category  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
