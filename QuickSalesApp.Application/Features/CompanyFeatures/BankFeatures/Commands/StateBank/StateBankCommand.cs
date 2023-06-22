using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.StateBank;


public sealed record StateBankCommand(
    string CompanyId,
    int BankId,
    bool IsActive,
    string UpdaterName

    ) :ICommand<StateBankCommandResponse>;
