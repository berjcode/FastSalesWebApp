using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.CreateCustomerType;

public sealed record CreateCustomerTypeCommand(
    string Name ,
    string creatorName,
    bool? isActive,
    string CompanyId
    ) : ICommand<CreateCustomerTypeCommandResponse>;

