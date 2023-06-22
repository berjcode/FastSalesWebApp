using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.StateCurrency;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.StateCurrency;

public sealed class StateCurrencyCommandHandler : ICommandHandler<StateCurrencyCommand, StateCurrencyCommandResponse>
{
    private readonly ICurrencyService _service;

    public StateCurrencyCommandHandler(ICurrencyService service)
    {
        _service = service;
    }
    public async Task<StateCurrencyCommandResponse> Handle(StateCurrencyCommand request, CancellationToken cancellationToken)
    {
        Currency currency = await _service.GetByIdAsync(request.CompanyId, request.CurrencyId);
        if (currency == null) throw new Exception("Bu Currency Bulunamadı");

        currency.IsActive = request.IsActive;
        currency.UpdaterName = request.UpdaterName;
        currency.UpdateDate = DateTime.Now;

        Currency newCurrency = await _service.ChangeState(request.CompanyId, currency);
        return new();
    }
}
