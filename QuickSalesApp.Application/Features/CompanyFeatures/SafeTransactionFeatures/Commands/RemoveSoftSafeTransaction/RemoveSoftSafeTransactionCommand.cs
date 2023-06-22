using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.RemoveSoftSafeTransaction;

public sealed record RemoveSoftSafeTransactionCommand(
    int Id,
    string CompanyId) : ICommand<RemoveSoftSafeTransactionCommandResponse>;