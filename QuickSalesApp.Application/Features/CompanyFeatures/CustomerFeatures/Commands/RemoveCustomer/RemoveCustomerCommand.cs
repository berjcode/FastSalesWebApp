using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.RemoveCustomer;
public sealed record RemoveCustomerCommand(
    int Id,
    string CompanyId) : ICommand<RemoveCustomerCommandResponse>;
