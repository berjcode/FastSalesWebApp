using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.RemoveBankTransaction;

public sealed class RemoveBankTransactionCommandValidator:AbstractValidator<RemoveBankTransactionCommand>
{
	public RemoveBankTransactionCommandValidator()
	{
        RuleFor(p => p.BankTransactionId).NotNull().WithMessage("BankTransactionId boş olamaz");
        RuleFor(p => p.BankTransactionId).NotEmpty().WithMessage("BankTransactionId boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
