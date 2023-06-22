using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.DeleteBank;

public sealed  record DeleteBankCommand(
    string CompanyId,
    int BankId,
    bool IsDelete,
    string DeleterName
    ) :ICommand<DeleteBankCommandResponse>;


