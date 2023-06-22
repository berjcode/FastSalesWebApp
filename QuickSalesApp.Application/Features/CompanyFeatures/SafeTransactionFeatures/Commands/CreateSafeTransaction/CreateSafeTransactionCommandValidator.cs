using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.CreateSafeTransaction;

public sealed class CreateSafeTransactionCommandValidator : AbstractValidator<CreateSafeTransactionCommand>
{
    public CreateSafeTransactionCommandValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
