

using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.RemoveCustomerType;

public sealed record RemoveCustomerTypeCommand(int id,
    string CompanyId) : ICommand<RemoveCustomerTypeCommandResponse>;
