using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.StateCustomer;

public sealed record StateCustomerCommand(
    string CompanyId,
    int CustomerId,
    bool IsActive,
    string UpdaterName

    ) :ICommand<StateCustomerCommandResponse>;
