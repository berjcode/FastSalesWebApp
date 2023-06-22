using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.RemoveCurrency;

public class RemoveCurrencyCommandValidator :AbstractValidator<RemoveCurrencyCommand>
{
	public RemoveCurrencyCommandValidator()
	{
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
