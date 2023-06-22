using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;

public class CreateCategoryCommandValidator :AbstractValidator<CreateCategoryCommand>   

{
	public CreateCategoryCommandValidator()
	{
        RuleFor(p => p.Name).NotNull().WithMessage("Name Bilgisi girilmelidir.");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Name Bilgisi girilmelidir.");
        RuleFor(p => p.Description).NotNull().WithMessage("Description Bilgisi girilmelidir.");
        RuleFor(p => p.Description).NotEmpty().WithMessage("Description Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
