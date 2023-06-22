using FluentValidation;
namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.DeleteBank;

public sealed class DeleteBankCommandValidator :AbstractValidator<DeleteBankCommand>
{
	public DeleteBankCommandValidator()
	{
        RuleFor(p => p.BankId).NotEmpty().WithMessage("BankId bilgisi boş olamaz.");
        RuleFor(p => p.BankId).NotNull().WithMessage("BankId  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
