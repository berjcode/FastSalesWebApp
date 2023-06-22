using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.UpdateBankTransaction;

public sealed class UpdateBankTransactionCommandValidator:AbstractValidator<UpdateBankTransactionCommand>
{
	public UpdateBankTransactionCommandValidator()
	{
        RuleFor(p => p.BankTransactionId).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.BankTransactionId).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
