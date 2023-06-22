using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.DeleteCustomerTransaction;

public sealed class DeleteCustomerTransactionCommandValidator :AbstractValidator<DeleteCustomerTransactionCommand>
{
	public DeleteCustomerTransactionCommandValidator()
	{
        RuleFor(p => p.CustomerTransactionId).NotEmpty().WithMessage("CustomerTransactionId bilgisi boş olamaz.");
        RuleFor(p => p.CustomerTransactionId).NotNull().WithMessage("CustomerTransactionId  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
