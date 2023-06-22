using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.RemoveProduct
{
    public sealed class RemoveProductCommandValidator : AbstractValidator<RemoveProductCommand>
    {
        public RemoveProductCommandValidator()
        {
            RuleFor(p => p.Id).NotNull().WithMessage("Id boş olamaz") ;
            RuleFor(p => p.Id).NotEmpty().WithMessage("Id boş olamaz") ;
            RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket Id boş olamaz") ;
            RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket Id boş olamaz") ;
        }
    }
}
