using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.RemovePersonal;

public sealed record RemovePersonalCommand(
        int id,
        string CompanyId
    ) : ICommand<RemovePersonalCommandResponse>;
