using FluentValidation;
namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.StateBank;

public sealed class StateBankCommandValidator :AbstractValidator<StateBankCommand>
{
	public StateBankCommandValidator()
    {
        RuleFor(p => p.BankId).NotEmpty().WithMessage("bankId bilgisi boş olamaz.");
        RuleFor(p => p.BankId).NotNull().WithMessage("bankId  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
