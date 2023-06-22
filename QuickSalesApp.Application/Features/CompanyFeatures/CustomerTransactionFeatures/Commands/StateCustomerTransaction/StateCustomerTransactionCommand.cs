using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.StateCustomerTransaction;

public sealed record StateCustomerTransactionCommand(
    string CompanyId,
    int CustomerTransactionId,
    bool IsActive,
    string UpdaterName
    ) :ICommand<StateCustomerTransactionCommandResponse>;
