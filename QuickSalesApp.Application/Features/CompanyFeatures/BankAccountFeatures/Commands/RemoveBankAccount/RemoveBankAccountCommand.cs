using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.RemoveBankAccount;

public sealed record RemoveBankAccountCommand(
    int BankAccountId,
    string CompanyId
    ) :ICommand<RemoveBankAccountCommandResponse>;
