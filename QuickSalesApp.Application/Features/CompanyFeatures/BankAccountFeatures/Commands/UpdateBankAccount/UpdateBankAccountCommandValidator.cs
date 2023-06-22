using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.UpdateBankAccount;

public sealed class UpdateBankAccountCommandValidator:AbstractValidator<UpdateBankAccountCommand>
{
	public UpdateBankAccountCommandValidator()
	{
        RuleFor(p => p.Id).NotEmpty().WithMessage("BankAccountID bilgisi boş olamaz.");
        RuleFor(p => p.Id).NotNull().WithMessage("BankAccountID  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
