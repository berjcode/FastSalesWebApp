using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.DeleteBankAccount;

public sealed record  DeleteBankAccountCommand(
     string CompanyId,
    int BankAccountId,
    bool IsDelete,
    string DeleterName

    ) : ICommand<DeleteBankAccountCommandResponse>;
