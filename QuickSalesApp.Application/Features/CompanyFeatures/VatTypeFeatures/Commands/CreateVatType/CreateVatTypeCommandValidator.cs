using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.CreateVatType;

public sealed class CreateVatTypeCommandValidator : AbstractValidator<CreateVatTypeCommand>
{
    public CreateVatTypeCommandValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
