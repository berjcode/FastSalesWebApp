using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.RemoveVatType;

public sealed class RemoveVatTypeCommandValidator : AbstractValidator<RemoveVatTypeCommand>
{
    public RemoveVatTypeCommandValidator()
    {
        RuleFor(p => p.id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.id).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
