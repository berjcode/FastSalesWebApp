using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.RemoveBank;

public sealed record RemoveBankCommand(
    int id,
    string CompanyId) : ICommand<RemoveBankCommandResponse>;
