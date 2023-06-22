using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.RemoveBank;

public class RemoveCategoryCommandValidator :AbstractValidator<RemoveBankCommand>
{
	public RemoveCategoryCommandValidator()
	{
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
