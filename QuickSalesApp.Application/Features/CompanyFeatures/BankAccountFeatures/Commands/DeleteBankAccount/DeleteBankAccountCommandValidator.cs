using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.DeleteBankAccount;

public sealed class DeleteBankAccountCommandValidator:AbstractValidator<DeleteBankAccountCommand>
{
	public DeleteBankAccountCommandValidator()
	{
        RuleFor(p => p.BankAccountId).NotEmpty().WithMessage("BankAccountId bilgisi boş olamaz.");
        RuleFor(p => p.BankAccountId).NotNull().WithMessage("BankAccountId  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
