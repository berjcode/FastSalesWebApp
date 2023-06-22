using FluentValidation;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.CreateProductType;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.CreateProductTransaction;

public sealed class CreateProductTransactionCommandValidator : AbstractValidator<CreateProductTypeCommand>
{
    public CreateProductTransactionCommandValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz");
    }
}
