using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.CreateTransactionType;

public sealed class CreateTransactionTypeCommandValidator : AbstractValidator<CreateTransactionTypeCommand>
{
    public CreateTransactionTypeCommandValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id Boş Olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id Boş Olamaz");
    }
}
