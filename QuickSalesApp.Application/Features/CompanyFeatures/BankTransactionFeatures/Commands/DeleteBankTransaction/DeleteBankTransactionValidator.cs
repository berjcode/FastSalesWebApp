using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.DeleteBankTransaction;

public sealed class DeleteBankTransactionValidator:AbstractValidator<DeleteBankTransactionCommand>
{
	public DeleteBankTransactionValidator()
	{
        RuleFor(p => p.BankTransactionId).NotNull().WithMessage("BankTransactionId boş olamaz");
        RuleFor(p => p.BankTransactionId).NotEmpty().WithMessage("BankTransactionId boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
