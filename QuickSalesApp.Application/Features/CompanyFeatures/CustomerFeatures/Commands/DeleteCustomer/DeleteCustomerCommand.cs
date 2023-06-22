using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.DeleteCustomer;

public sealed  record DeleteCustomerCommand(
    string CompanyId,
    int CustomerId,
    bool IsDelete,
    string DeleterName
    ) :ICommand<DeleteCustomerCommandResponse>;



