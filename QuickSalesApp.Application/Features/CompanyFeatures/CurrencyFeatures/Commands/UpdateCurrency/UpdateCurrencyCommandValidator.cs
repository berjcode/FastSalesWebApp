using FluentValidation;
namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.UpdateCurrency;

public sealed class UpdateCurrencyCommandValidator :AbstractValidator<UpdateCurrencyCommand>
{
    public UpdateCurrencyCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Category bilgisi boş olamaz.");
        RuleFor(p => p.Id).NotNull().WithMessage("Category  Bilgisi girilmelidir.");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id bilgisi boş olamaz.");
        RuleFor(p => p.Id).NotNull().WithMessage("Id  Bilgisi girilmelidir.");
    }
}
