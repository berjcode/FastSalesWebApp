using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.CreateBankAccount;

public sealed class CreateBankAccountCommandValidator:AbstractValidator<CreateBankAccountCommand>
{
	public CreateBankAccountCommandValidator()
	{
        RuleFor(p => p.Name).NotNull().WithMessage("Name Bilgisi girilmelidir.");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Name Bilgisi girilmelidir.");
        RuleFor(p => p.Code).NotNull().WithMessage("Description Bilgisi girilmelidir.");
        RuleFor(p => p.Code).NotEmpty().WithMessage("Description Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
