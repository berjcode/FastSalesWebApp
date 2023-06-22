using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.StateSafeTransaction;

public sealed class StateSafeTransactionCommandValidator : AbstractValidator<StateSafeTransactionCommand>
{
    public StateSafeTransactionCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().WithMessage("Id Boş Olamaz");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id Boş Olamaz");

        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id Boş Olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id Boş Olamaz");

        RuleFor(p => p.DeleterName).NotNull().WithMessage("Silen Kişi İsmi Boş Olamaz");
        RuleFor(p => p.DeleterName).NotEmpty().WithMessage("Silen Kişi İsmi Boş Olamaz");
    }
}
