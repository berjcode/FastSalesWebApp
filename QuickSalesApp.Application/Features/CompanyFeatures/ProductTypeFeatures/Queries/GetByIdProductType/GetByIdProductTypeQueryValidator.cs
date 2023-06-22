using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetByIdProductType;

public sealed class GetByIdProductTypeQueryValidator : AbstractValidator<GetByIdProductTypeQuery>
{
    public GetByIdProductTypeQueryValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket id boş olamaz");
    }
}
