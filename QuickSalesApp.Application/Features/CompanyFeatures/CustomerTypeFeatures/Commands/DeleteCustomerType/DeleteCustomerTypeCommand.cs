using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.DeleteCustomerType;
public sealed  record DeleteCustomerTypeCommand(
    string CompanyId,
    int CustomerTypeId,
    bool IsDelete,
    string DeleterName
    ) :ICommand<DeleteCustomerTypeCommandResponse>;


