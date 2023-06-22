using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.RemoveSafe;

public sealed record RemoveSafeCommand(
    int id,
    string CompanyId) : ICommand<RemoveSafeCommandResponse>;