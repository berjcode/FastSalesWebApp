using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetByIdProductTransaction;

public sealed class GetByIdProductTransactionQueryValidator : AbstractValidator<GetByIdProductTransactionQuery>
{
    public GetByIdProductTransactionQueryValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket id boş olamaz");
    }
}
