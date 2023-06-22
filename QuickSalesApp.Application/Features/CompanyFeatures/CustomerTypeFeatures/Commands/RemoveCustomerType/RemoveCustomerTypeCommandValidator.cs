using FluentValidation;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.RemoveCustomerType;

public sealed class RemoveCustomerTypeCommandValidator : AbstractValidator<RemoveCustomerTypeCommand>
{
    public RemoveCustomerTypeCommandValidator()
    {
        RuleFor(p => p.id).NotEmpty().WithMessage("Id Alanı Boş Olamaz");
        RuleFor(p => p.id).NotNull().WithMessage("Id Alanı Boş Olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz!");
    }
}
