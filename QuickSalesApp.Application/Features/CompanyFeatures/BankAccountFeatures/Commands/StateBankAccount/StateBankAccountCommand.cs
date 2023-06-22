using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.StateBankAccount;

public sealed record StateBankAccountCommand(
    string CompanyId,
    int BankAccountId,
    bool IsActive,
    string UpdaterName
    ) : ICommand<StateBankAccountCommandResponse>;
