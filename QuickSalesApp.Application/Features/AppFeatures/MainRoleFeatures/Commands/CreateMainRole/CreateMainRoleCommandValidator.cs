using FluentValidation;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateAllMainRoles;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;

public sealed class CreateMainRoleCommandValidator : AbstractValidator<CreateMainRoleCommand>
{
    public CreateMainRoleCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Rol başlığı boş olamaz");
        RuleFor(x => x.Title).NotNull().WithMessage("Rol başlığı boş olamaz");
    }
}
