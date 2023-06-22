using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.CreatePersonal;

public sealed class CreatePersonalCommandValidator : AbstractValidator<CreatePersonalCommand>
{
    public CreatePersonalCommandValidator()
    {
        RuleFor(p => p.Code).NotNull().WithMessage("Personel Kodu Boş Olamaz");
        RuleFor(p => p.Code).NotEmpty().WithMessage("Personel Kodu Boş Olamaz");

        RuleFor(p => p.Name).NotNull().WithMessage("Personel Adı Boş Olamaz");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Personel Adı Boş Olamaz");

        RuleFor(p => p.Email).NotNull().WithMessage("Personel Mail Adresi Boş Olamaz");
        RuleFor(p => p.Email).NotEmpty().WithMessage("Personel Mail Adresi Boş Olamaz");

        RuleFor(p => p.DepartmentId).NotNull().WithMessage("Personel Departman Id Boş Olamaz");
        RuleFor(p => p.DepartmentId).NotEmpty().WithMessage("Personel Departman Id Boş Olamaz");

        RuleFor(p => p.CompanyId).NotNull().WithMessage("Personel Şirket Id Boş Olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Personel Şirket Id Boş Olamaz");
    }
}
