using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.StateDepartment;

public sealed class StateDepartmentCommandValidator : AbstractValidator<StateDepartmentCommand>
{
	public StateDepartmentCommandValidator()
    {
        RuleFor(p => p.DepartmanId).NotEmpty().WithMessage("Departman bilgisi boş olamaz.");
        RuleFor(p => p.DepartmanId).NotNull().WithMessage("Departman  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
