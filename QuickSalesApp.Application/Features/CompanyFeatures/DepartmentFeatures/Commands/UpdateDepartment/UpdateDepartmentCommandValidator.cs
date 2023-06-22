using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.UpdateDepartment;

public sealed class UpdateCustomerCommandValidator:AbstractValidator<UpdateDepartmentCommand>
{
	public UpdateCustomerCommandValidator()
	{
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id alanı boş olamaz!");
        RuleFor(p => p.Id).NotNull().WithMessage("Id alanı boş olamaz!");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket bilgisi boş olamaz!");
        RuleFor(p => p.Name).NotEmpty().WithMessage("Name bilgisi boş olamaz!");
        RuleFor(p => p.Name).NotNull().WithMessage("Name bilgisi boş olamaz!");
    }
}
