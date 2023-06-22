

using FluentValidation;

namespace QuickSalesApp.Application.Features.AppFeatures.MainRoleAndUserRL.Commands.CreateMainRoleAndUserRL;

public sealed class CreateMainRoleAndUserRLCommandValidator : AbstractValidator<CreateMainRoleAndUserRLCommand>
{

    public CreateMainRoleAndUserRLCommandValidator()
    {

        RuleFor(p => p.UserId).NotEmpty().WithMessage("Kullanıcı seçmelisiniz");
        RuleFor(p => p.UserId).NotNull().WithMessage("Kullanıcı seçmelisiniz");


        RuleFor(p => p.CompanyId).NotEmpty().WithMessage("Şirket seçmelisiniz.");
        RuleFor(p => p.CompanyId).NotNull().WithMessage("Şirket seçmelisiniz.");

        RuleFor(p => p.MainRoleId).NotEmpty().WithMessage("Anarol seçmelisiniz");
        RuleFor(p => p.MainRoleId).NotNull().WithMessage("Anarol seçmelisiniz");
    }
}
