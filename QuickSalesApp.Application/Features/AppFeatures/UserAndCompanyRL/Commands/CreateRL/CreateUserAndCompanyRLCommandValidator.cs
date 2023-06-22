
using FluentValidation;

namespace QuickSalesApp.Application.Features.AppFeatures.UserAndCompanyRL.Commands.CreateRL;

public sealed class CreateUserAndCompanyRLCommandValidator :AbstractValidator<CreateUserAndCompanyRLCommand>
{

	public CreateUserAndCompanyRLCommandValidator()
	{
		RuleFor(p=> p.AppUserId).NotEmpty().WithMessage("Kullanıcı Seçilmelidir.");
        RuleFor(p => p.AppUserId).NotNull().WithMessage("Kullanıcı Seçilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Seçilmelidir.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Seçilmelidir.");
    }
}
