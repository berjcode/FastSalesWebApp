using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetAllProductTransaction;

public sealed class GetAllProductTransactionQueryValidator  :AbstractValidator<GetAllProductTransactionQuery>
{
    public GetAllProductTransactionQueryValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket id boş olamaz");
    }
}
