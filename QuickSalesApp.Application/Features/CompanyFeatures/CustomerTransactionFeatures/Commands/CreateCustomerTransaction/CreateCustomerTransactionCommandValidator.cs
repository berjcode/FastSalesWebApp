using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.CreateCustomerTransaction;

public sealed class CreateCustomerTransactionCommandValidator:AbstractValidator<CreateCustomerTransactionCommand>
{
	public CreateCustomerTransactionCommandValidator()
	{
        RuleFor(p => p.CustomerCode).NotNull().WithMessage("CustomerCode Bilgisi girilmelidir.");
        RuleFor(p => p.CustomerCode).NotEmpty().WithMessage("CustomerCode Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
