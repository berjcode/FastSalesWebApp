using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.RemoveBankAccount;

public sealed class RemoveBankAccountCommandValidator:AbstractValidator<RemoveBankAccountCommand>
{
	public RemoveBankAccountCommandValidator()
	{

        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
