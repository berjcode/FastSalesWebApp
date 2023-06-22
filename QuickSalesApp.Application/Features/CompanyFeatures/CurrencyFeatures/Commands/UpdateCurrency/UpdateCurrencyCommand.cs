using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.UpdateCurrency;

public sealed record UpdateCurrencyCommand(

     string CompanyId,
    int Id,
    string Name,
    string UpdaterName) : ICommand<UpdateCurrencyCommandResponse>;

