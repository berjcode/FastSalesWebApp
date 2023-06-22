using FluentValidation;

namespace QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole
{
    public sealed class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator()
        {

            RuleFor(p => p.Id).NotNull().WithMessage("Id Bilgisi girilmelidir.");

            RuleFor(p => p.Id).NotEmpty().WithMessage("Id Bilgisi girilmelidir.");

          
        }
    }
}
