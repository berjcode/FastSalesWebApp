using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.RemoveCustomer;

public sealed class RemoveCustomerCommandValidator :AbstractValidator<RemoveCustomerCommand>
{
	public RemoveCustomerCommandValidator()
	{
        RuleFor(p => p.Id).NotNull().WithMessage("Id boş olamaz");
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id boş olamaz");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
