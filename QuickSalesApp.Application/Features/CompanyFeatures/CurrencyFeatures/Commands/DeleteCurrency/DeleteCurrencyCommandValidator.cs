using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.DeleteCurrency;

public sealed class DeleteCurrencyCommandValidator : AbstractValidator<DeleteCurrencyCommand>
{
    public DeleteCurrencyCommandValidator()
    {
        RuleFor(p => p.CurrencyId).NotEmpty().WithMessage("CurrencyId bilgisi boş olamaz.");
        RuleFor(p => p.CurrencyId).NotNull().WithMessage("CurrencyId  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
