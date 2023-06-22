using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.UpdateBankAccount;

public sealed record UpdateBankAccountCommand(
        int Id,
      string Code,
    string Name,
    string IBAN,
   string AcountNumber,
  int CurrencyId,
   string CompanyId

    ) :ICommand<UpdateBankAccountCommandResponse>;
