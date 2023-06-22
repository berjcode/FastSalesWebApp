using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetAllProductType;

public sealed class GetAllProductTypeQueryValidator :AbstractValidator<GetAllProductTypeQuery>
{
    public GetAllProductTypeQueryValidator()
    {
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket id boş olamaz");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket id boş olamaz");
    }
}
