using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetByIdProductUnit;

public sealed class GetByIdProductUnitQueryValidator : AbstractValidator<GetByIdProductUnitQuery>
{
    public GetByIdProductUnitQueryValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket id boş olamaz");
    }
}
