using FluentValidation;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.CreateMainRole;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.CreateMainRoleRL;

public sealed class CreateMainRoleAndRoleRlCommandValidator : AbstractValidator<CreateMainRoleAndRoleRLCommand>
{
    public CreateMainRoleAndRoleRlCommandValidator()
    {
        RuleFor(p => p.RoleId).NotEmpty().WithMessage("Rol Seçilmelidir.");
        RuleFor(p => p.RoleId).NotNull().WithMessage("Rol Seçilmelidir.");
        RuleFor(p => p.MainRoleId).NotEmpty().WithMessage("Ana rol Seçilmelidir.");
        RuleFor(p => p.MainRoleId).NotEmpty().WithMessage("Ana rol Seçilmelidir.");


    }
}
