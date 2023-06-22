using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.StateCustomer;

public sealed class StateCustomerCommandValidator : AbstractValidator<StateCustomerCommand>
{
	public StateCustomerCommandValidator()
    {
        RuleFor(p => p.CustomerId).NotEmpty().WithMessage("CustomerId bilgisi boş olamaz.");
        RuleFor(p => p.CustomerId).NotNull().WithMessage("CustomerId  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
