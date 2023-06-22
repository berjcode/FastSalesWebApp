using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.StateCustomerType;

public sealed record StateCustomerTypeCommand(
    string CompanyId,
    int CustomerTypeId,
    bool IsActive,
    string UpdaterName

    ) :ICommand<StateCustomerTypeCommandResponse>;
