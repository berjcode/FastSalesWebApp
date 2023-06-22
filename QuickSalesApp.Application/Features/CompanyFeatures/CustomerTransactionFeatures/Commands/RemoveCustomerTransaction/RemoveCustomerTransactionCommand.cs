using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.RemoveCustomerTransaction;

public sealed record RemoveCustomerTransactionCommand(
    int CustomerTransactionId,
    string CompanyId) :ICommand<RemoveCustomerTransactionCommandResponse>;
