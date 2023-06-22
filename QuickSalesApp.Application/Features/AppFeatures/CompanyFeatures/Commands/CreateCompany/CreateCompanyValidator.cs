using FluentValidation;

namespace QuickSalesApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyValidator()
        {
            RuleFor(p => p.DatabaseName).NotNull().WithMessage("Database Bilgisi girilmelidir.");
            RuleFor(p => p.DatabaseName).NotEmpty().WithMessage("Database Bilgisi girilmelidir.");
            RuleFor(p => p.ServerName).NotEmpty().WithMessage("ServerName Bilgisi girilmelidir.");
            RuleFor(p => p.ServerName).NotEmpty().WithMessage("ServerName Bilgisi girilmelidir.");

            RuleFor(p => p.Name).NotNull().WithMessage("Şirket Adı girilmelidir.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Şİrket Adı girilmelidir.");
        }
    }
}
