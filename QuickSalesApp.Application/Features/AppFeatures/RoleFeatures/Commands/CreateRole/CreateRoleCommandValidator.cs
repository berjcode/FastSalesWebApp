using FluentValidation;

namespace QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole
{
   public sealed class CreateRoleCommandValidator :AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(p => p.Code).NotNull().WithMessage("Code Bilgisi girilmelidir.");
            RuleFor(p => p.Code).NotEmpty().WithMessage("Code  Bilgisi girilmelidir.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Role Bilgisi girilmelidir.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Role Bilgisi girilmelidir.");
        }

    }
}
