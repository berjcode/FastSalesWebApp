using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.UpdatePersonal;

public sealed class UpdatePersonalCommandValidator : AbstractValidator<UpdatePersonalCommand>
{
    public UpdatePersonalCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().WithMessage("Id Boş Olamaz");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id Boş Olamaz");

        RuleFor(p => p.CompanyId).NotNull().WithMessage("CompanyId Boş Olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("CompanyId Boş Olamaz");
    }
}
