using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.DeleteCustomerType;

public sealed class DeleteCustomerTypeCommandValidator : AbstractValidator<DeleteCustomerTypeCommand>
{
    public DeleteCustomerTypeCommandValidator()
    {

        RuleFor(p => p.CustomerTypeId).NotEmpty().WithMessage("Departman bilgisi boş olamaz.");
        RuleFor(p => p.CustomerTypeId).NotNull().WithMessage("Departman  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
