using FluentValidation;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.DeleteDepartment;

public sealed class DeleteCustomerCommandValidator : AbstractValidator<DeleteDepartmentCommand>
{
    public DeleteCustomerCommandValidator()
    {

        RuleFor(p => p.DepartmentId).NotEmpty().WithMessage("Departman bilgisi boş olamaz.");
        RuleFor(p => p.DepartmentId).NotNull().WithMessage("Departman  Bilgisi girilmelidir.");
        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket bilgisi boş olamaz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket  Bilgisi girilmelidir.");
    }
}
