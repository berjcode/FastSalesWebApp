using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.StatePersonal
{
    public sealed record StatePersonalCommand(
            int Id,
            string CompanyId,
            bool IsActive,
            string DeleterName
        ) : ICommand<StatePersonalCommandResponse>;
}
