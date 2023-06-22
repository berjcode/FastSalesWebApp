

using QuickSalesApp.Application.Messaging;


namespace QuickSalesApp.Application.Features.AppFeatures.UserAndCompanyRL.Commands.RemoveByIdRL;

public sealed record RemoveByIdUserAndCompanyRLCommand (string Id ) : ICommand<RemoveByIdUserAndCompanyRLCommandResponse>;


