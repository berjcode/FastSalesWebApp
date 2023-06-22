using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.RemoveSoftPersonal;

public sealed record RemoveSoftPersonalCommand(
        int Id,
        string CompanyId
    ) : ICommand<RemoveSoftPersonalCommandResponse>;
