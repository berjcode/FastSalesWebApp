using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetById
{
    public sealed class GetByIdPersonalQueryValidator : AbstractValidator<GetByIdPersonalQuery>
    {
        public GetByIdPersonalQueryValidator()
        {
            RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket id boş olamaz");
            RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket id boş olamaz");
        }
    }
}
