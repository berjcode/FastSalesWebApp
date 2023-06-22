using FluentValidation;

namespace QuickSalesApp.Application.Features.AppFeatures.UserFeatures.Commands.Create;

public sealed  class CreateUserCommandValidator :AbstractValidator<CreateUserCommand>
{
	public CreateUserCommandValidator()
	{
		RuleFor(p=> p.userName).NotEmpty().WithMessage("Boş Geçilemez.");
        RuleFor(p => p.userName).NotNull().WithMessage("Boş Geçilemez.");
        RuleFor(p => p.surName).NotEmpty().WithMessage("Boş Geçilemez.");
        RuleFor(p => p.surName).NotNull().WithMessage("Boş Geçilemez.");
        RuleFor(p => p.email).NotEmpty().WithMessage("Boş Geçilemez.");
        RuleFor(p => p.email).NotNull().WithMessage("Boş Geçilemez.");

        RuleFor(p => p.password).NotNull()
                .WithMessage("Şifre Boş Olamaz");
        RuleFor(p => p.password).NotEmpty()
            .WithMessage("Şifre Boş Olamaz");
        RuleFor(p => p.password).MinimumLength(4).WithMessage("Şifre en az 4 karakter olabilir.");
        RuleFor(p => p.password).Matches("[A-Z]").WithMessage("Şifre en az 1 büyük karakter  olmalıdır.");
        RuleFor(p => p.password).Matches("[a-z]").WithMessage("Şifre en az 1 küçük karakter  olmalıdır.");
        RuleFor(p => p.password).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet sayı içermelidir.");
        RuleFor(p => p.password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir.");
    }
}
