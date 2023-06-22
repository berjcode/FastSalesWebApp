using FluentValidation;

namespace QuickSalesApp.Application.Features.AppFeatures.AuthFeatures.Commands.Login
{
    public sealed class LoginCommandValidator : AbstractValidator<UserCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(p => p.EmailAndUserName).NotNull()
               .WithMessage("Mail veya Kullanıcı Adı Girmelisiniz");
            RuleFor(p => p.EmailAndUserName).NotEmpty()
                .WithMessage("Mail veya Kullanıcı Adı Girmelisiniz");
            //Password
            RuleFor(p => p.Password).NotNull()
                .WithMessage("Şifre Boş Olamaz");
            RuleFor(p => p.Password).NotEmpty()
                .WithMessage("Şifre Boş Olamaz");
            RuleFor(p => p.Password).MinimumLength(4).WithMessage("Şifre en az 4 karakter olabilir.");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Şifre en az 1 büyük karakter  olmalıdır.");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Şifre en az 1 küçük karakter  olmalıdır.");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Şifreniz en az 1 adet sayı içermelidir.");
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Şifreniz en az 1 adet özel karakter içermelidir.");
        }
    }
}
