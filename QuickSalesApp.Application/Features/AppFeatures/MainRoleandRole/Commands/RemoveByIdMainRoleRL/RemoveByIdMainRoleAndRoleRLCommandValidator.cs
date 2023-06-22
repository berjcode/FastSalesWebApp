using FluentValidation;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.RemoveMainRoleRL;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.RemoveByIdMainRoleRL;

public sealed class RemoveByIdMainRoleAndRoleRLCommandValidator : AbstractValidator<RemoveByIdMainRoleAndRoleRlCommand>
{
    public RemoveByIdMainRoleAndRoleRLCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Id alanı zorunludur.");
        RuleFor(p => p.Id).NotNull().WithMessage("Id alanı zorunludur.");
    }
}
