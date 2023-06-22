using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.CreateCustomerType;

public sealed class CreateCustomerTypeCommandValidator : AbstractValidator<CreateCustomerTypeCommand>
{
    public CreateCustomerTypeCommandValidator()
    {
        RuleFor(p => p.Name).NotNull().WithMessage("name Bilgisi girilmelidir.");
        RuleFor(p => p.Name).NotEmpty().WithMessage("name Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
