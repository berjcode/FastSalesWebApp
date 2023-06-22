

using FluentValidation;

namespace QuickSalesApp.Application.Features.AppFeatures.UserAndCompanyRL.Commands.RemoveByIdRL;

public sealed class RemoveByIdUserAndCompanyRLCommandValidator : AbstractValidator<RemoveByIdUserAndCompanyRLCommand>
{
    public RemoveByIdUserAndCompanyRLCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id Alanı boş olamaz.");
        RuleFor(p => p.Id).NotNull().WithMessage("Id Alanı Boş Olamaz");
    }
}
