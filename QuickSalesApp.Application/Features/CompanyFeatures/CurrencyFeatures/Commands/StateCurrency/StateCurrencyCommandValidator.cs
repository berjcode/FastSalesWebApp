using FluentValidation;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.StateCurrency;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.StateCurrency;

public sealed class StateCurrencyCommandValidator :AbstractValidator<StateCurrencyCommand>
{
	public StateCurrencyCommandValidator()
    {
        RuleFor(p => p.CurrencyId).NotEmpty().WithMessage("CurrencyId bilgisi boş olamaz.");
        RuleFor(p => p.CurrencyId).NotNull().WithMessage("CurrencyId  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
