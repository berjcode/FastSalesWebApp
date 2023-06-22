using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.UpdateBank;

public sealed class UpdateBankCommandValidator :AbstractValidator<UpdateBankCommand>
{
    public UpdateBankCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("BankID bilgisi boş olamaz.");
        RuleFor(p => p.Id).NotNull().WithMessage("BankID  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
