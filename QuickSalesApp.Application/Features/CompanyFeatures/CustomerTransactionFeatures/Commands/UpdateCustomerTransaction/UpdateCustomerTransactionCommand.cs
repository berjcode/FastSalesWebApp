using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.UpdateCustomerTransaction;

public sealed record UpdateCustomerTransactionCommand(
    string CompanyId,
    int CustomerTransactionId,
     string PlugNo,
    string CustomerCode,
    DateTime TransactionDate,
    string Text,
    string Description,
    decimal Debt,
    decimal Credit,
    decimal Remainder,
    int ProcessTypeId,
    string UpdaterName
    ) :ICommand<UpdateCustomerTransactionCommandResponse>;
