using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.RemoveCurrency;

public sealed record RemoveCurrencyCommand(
    int id,
    string CompanyId) : ICommand<RemoveCurrencyCommandResponse>;
