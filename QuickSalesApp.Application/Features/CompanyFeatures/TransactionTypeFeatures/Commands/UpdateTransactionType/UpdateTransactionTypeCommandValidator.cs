using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.UpdateTransactionType;

public sealed class UpdateTransactionTypeCommandValidator : AbstractValidator<UpdateTransactionTypeCommand>
{
    public UpdateTransactionTypeCommandValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");

        RuleFor(p => p.Id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id boş olamaz");
    }
}
