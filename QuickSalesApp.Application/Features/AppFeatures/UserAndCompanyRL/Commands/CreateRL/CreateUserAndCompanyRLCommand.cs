
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.AppFeatures.UserAndCompanyRL.Commands.CreateRL;

public sealed record  CreateUserAndCompanyRLCommand(
    string AppUserId,
    string CompanyId
    ): ICommand<CreateUserAndCompanyRLCommandResponse>;
