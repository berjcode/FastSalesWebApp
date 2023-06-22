using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.CreateCurrency;

public sealed record CreateCurrencyCommand(
    string Name,
    string CreatorName, 
    string CompanyId

  ) : ICommand<CreateCurrencyCommandResponse>;

