using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.DeleteCurrency;

public sealed  record DeleteCurrencyCommand(
    string CompanyId,
    int CurrencyId,
    bool IsDelete,
    string DeleterName
    ) :ICommand<DeleteCurrencyCommandResponse>;


