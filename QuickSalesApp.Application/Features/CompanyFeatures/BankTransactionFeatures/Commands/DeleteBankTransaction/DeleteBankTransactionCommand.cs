using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.DeleteBankTransaction;

public sealed record DeleteBankTransactionCommand(
     int BankTransactionId,
    string CompanyId
    ):ICommand<DeleteBankTransactionResponse>;