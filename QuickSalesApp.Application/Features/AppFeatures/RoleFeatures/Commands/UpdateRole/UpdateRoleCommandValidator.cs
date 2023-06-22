
using FluentValidation;

namespace QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole
{
   public sealed class UpdateRoleCommandValidator :AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {

            RuleFor(p => p.Id).NotNull().WithMessage("Id Bilgisi girilmelidir.");

            RuleFor(p => p.Id).NotEmpty().WithMessage("Id Bilgisi girilmelidir.");

            RuleFor(p => p.Code).NotNull().WithMessage("Code Bilgisi girilmelidir.");
            RuleFor(p => p.Code).NotEmpty().WithMessage("Code  Bilgisi girilmelidir.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Role Bilgisi girilmelidir.");
            RuleFor(p => p.Name).NotEmpty().WithMessage("Role Bilgisi girilmelidir.");
        }
    }
}
