using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.CreateBankAccount;

public sealed record CreateBankAccountCommand(
    
    string Code,
    string Name,
    string IBAN,
   string AcountNumber, 
    int CurrencyId ,

   string CompanyId,
   int BankId
     ) :ICommand<CreateBankAccountCommandResponse>;




