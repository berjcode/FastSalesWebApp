using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.RemoveBankTransaction;

public sealed record RemoveBankTransactionCommand(
     int BankTransactionId,
    string CompanyId
    ) :ICommand<RemoveBankTransactionCommandResponse>;
