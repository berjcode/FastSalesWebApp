using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.RemoveCustomerTransaction;

public sealed class RemoveCustomerTransactionCommandValidator:AbstractValidator<RemoveCustomerTransactionCommand>
{
	public RemoveCustomerTransactionCommandValidator()
	{
        RuleFor(p => p.CustomerTransactionId).NotEmpty().WithMessage("CustomerTransactionId Alanı Boş Olamaz");
        RuleFor(p => p.CustomerTransactionId).NotNull().WithMessage("CustomerTransactionId Alanı Boş Olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz!");
    }
}
