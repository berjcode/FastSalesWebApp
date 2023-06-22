using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.RemoveProductTransaction;

public sealed record RemoveProductTransactionCommand(
    int id,
    string CompanyId) : ICommand<RemoveProductTransactionCommandResponse>;