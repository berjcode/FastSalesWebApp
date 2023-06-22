using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.CreateBank;

public class CreateBankCommandValidator :AbstractValidator<CreateBankCommand>   

{
	public CreateBankCommandValidator()
	{
        RuleFor(p => p.Name).NotNull().WithMessage("Name Bilgisi girilmelidir.");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Name Bilgisi girilmelidir.");
        RuleFor(p => p.Code).NotNull().WithMessage("Description Bilgisi girilmelidir.");
        RuleFor(p => p.Code).NotEmpty().WithMessage("Description Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
