using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.CreateBankTransaction;

public sealed class CreateBankTransactionCommandValidator:AbstractValidator<CreateBankTransactionCommand>
{
	public CreateBankTransactionCommandValidator()
	{
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
