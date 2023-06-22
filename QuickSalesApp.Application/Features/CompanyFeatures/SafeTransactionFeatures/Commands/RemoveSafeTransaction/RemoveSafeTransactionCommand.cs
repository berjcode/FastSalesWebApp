using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.RemoveSafeTransaction;

public sealed record RemoveSafeTransactionCommand(
    int id,
    string CompanyId) : ICommand<RemoveSafeTransactionCommandResponse>;