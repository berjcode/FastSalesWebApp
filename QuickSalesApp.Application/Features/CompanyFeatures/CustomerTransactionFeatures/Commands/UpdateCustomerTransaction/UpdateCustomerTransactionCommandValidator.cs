using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.UpdateCustomerTransaction;

public sealed class UpdateCustomerTransactionCommandValidator:AbstractValidator<UpdateCustomerTransactionCommand>
{
	public UpdateCustomerTransactionCommandValidator()
	{
        RuleFor(p => p.CustomerTransactionId).NotEmpty().WithMessage("CustomerTransactionId alanı boş olamaz!");
        RuleFor(p => p.CustomerTransactionId).NotNull().WithMessage("CustomerTransactionId alanı boş olamaz!");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(p => p.PlugNo).NotEmpty().WithMessage("PlugNo bilgisi boş olamaz!");
        RuleFor(p => p.PlugNo).NotNull().WithMessage("PlugNo bilgisi boş olamaz!");
    }
}
