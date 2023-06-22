using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.StateTransactionType;

public sealed class StateTransactionTypeCommandValidator : AbstractValidator<StateTransactionTypeCommand>
{
    public StateTransactionTypeCommandValidator()
    {
        RuleFor(p => p.Id).NotNull().WithMessage("Id Boş Olamaz");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id Boş Olamaz");

        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id Boş Olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id Boş Olamaz");

        RuleFor(p => p.DeleterName).NotNull().WithMessage("Silen Kişi İsmi Boş Olamaz");
        RuleFor(p => p.DeleterName).NotEmpty().WithMessage("Silen Kişi İsmi Boş Olamaz");
    }
}
