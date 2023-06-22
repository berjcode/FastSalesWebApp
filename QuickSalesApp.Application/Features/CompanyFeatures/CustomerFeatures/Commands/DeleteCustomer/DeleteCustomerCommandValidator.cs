using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.DeleteCustomer;

public sealed class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {

        RuleFor(p => p.CustomerId).NotEmpty().WithMessage("CustomerId bilgisi boş olamaz.");
        RuleFor(p => p.CustomerId).NotNull().WithMessage("CustomerId  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
