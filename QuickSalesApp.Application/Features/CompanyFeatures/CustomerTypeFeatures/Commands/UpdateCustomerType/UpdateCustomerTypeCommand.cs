using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.UpdateCustomerType;
public sealed  record UpdateCustomerTypeCommand  (string CompanyId,
    int Id,
    string Name,
    string updaterName

    ): ICommand<UpdateCustomerTypeCommandResponse>;
