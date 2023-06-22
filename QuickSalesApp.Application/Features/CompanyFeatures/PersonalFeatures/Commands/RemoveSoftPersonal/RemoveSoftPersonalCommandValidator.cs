using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.RemoveSoftPersonal;

public sealed class RemoveSoftPersonalCommandValidator : AbstractValidator<RemoveSoftPersonalCommand>
{
    public RemoveSoftPersonalCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
