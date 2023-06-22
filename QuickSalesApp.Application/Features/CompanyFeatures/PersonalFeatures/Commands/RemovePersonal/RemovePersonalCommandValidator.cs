using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.RemovePersonal;

public sealed class RemovePersonalCommandValidator : AbstractValidator<RemovePersonalCommand>
{
    public RemovePersonalCommandValidator()
    {
        RuleFor(p => p.id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.id).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");

    }
}
