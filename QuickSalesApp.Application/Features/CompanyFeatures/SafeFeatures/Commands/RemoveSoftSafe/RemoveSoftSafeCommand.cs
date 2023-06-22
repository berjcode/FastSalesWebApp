using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.RemoveSoftSafe;

public sealed record RemoveSoftSafeCommand(
    int id,
    string CompanyId) : ICommand<RemoveSoftSafeCommandResponse>;