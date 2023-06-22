
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.StateCurrency;

public sealed record StateCurrencyCommand(
    string CompanyId,
    int CurrencyId,
    bool IsActive,
    string UpdaterName

    ) : ICommand<StateCurrencyCommandResponse>;
