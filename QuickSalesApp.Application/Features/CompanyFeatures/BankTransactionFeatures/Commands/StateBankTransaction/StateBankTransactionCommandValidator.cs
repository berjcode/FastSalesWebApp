using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.StateBankTransaction;

public sealed class StateBankTransactionCommandValidator:AbstractValidator<StateBankTransactionCommand>
{
	public StateBankTransactionCommandValidator()
	{
        RuleFor(p => p.BankTransactionId).NotNull().WithMessage("BankTransactionId Boş Olamaz");
        RuleFor(p => p.BankTransactionId).NotEmpty().WithMessage("BankTransactionId Boş Olamaz");

        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id Boş Olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id Boş Olamaz");

        RuleFor(p => p.UpdaterName).NotNull().WithMessage("Güncelleyen Kişi İsmi Boş Olamaz");
        RuleFor(p => p.UpdaterName).NotEmpty().WithMessage("Güncelleyen Kişi İsmi Boş Olamaz");
    }
}
