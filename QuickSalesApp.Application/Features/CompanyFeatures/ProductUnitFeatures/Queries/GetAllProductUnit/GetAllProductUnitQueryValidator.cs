using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllProductUnit;

public sealed class GetAllProductUnitQueryValidator : AbstractValidator<GetAllProductUnitQuery>
{
    public GetAllProductUnitQueryValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket id boş olamaz");
    }
}
