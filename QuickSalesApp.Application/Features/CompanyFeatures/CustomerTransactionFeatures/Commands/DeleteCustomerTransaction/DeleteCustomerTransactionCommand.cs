using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.DeleteCustomerTransaction;

public sealed  record DeleteCustomerTransactionCommand(
    string CompanyId,
    int CustomerTransactionId,
    bool IsDelete,
    string DeleterName
    ) : ICommand<DeleteCustomerTransactionCommandResponse>;
