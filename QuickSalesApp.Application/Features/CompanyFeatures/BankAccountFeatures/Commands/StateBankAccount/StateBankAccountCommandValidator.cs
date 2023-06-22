using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.StateBankAccount;

public sealed class StateBankAccountCommandValidator:AbstractValidator<StateBankAccountCommand>
{
	public StateBankAccountCommandValidator()
	{
        RuleFor(p => p.BankAccountId).NotEmpty().WithMessage("BankAccountId bilgisi boş olamaz.");
        RuleFor(p => p.BankAccountId).NotNull().WithMessage("BankAccountId  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
