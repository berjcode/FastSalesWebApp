using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.CreateCustomerTransaction;

public sealed record CreateCustomerTransactionCommand(


   string PlugNo ,
 string CustomerCode ,
 DateTime TransactionDate,
 string Text ,
 string Description ,
 decimal Debt ,
 decimal Credit ,
 decimal Remainder ,
 int ProcessTypeId,
 string CompanyId) :ICommand<CreateCustomerTransactionCommandResponse>;




