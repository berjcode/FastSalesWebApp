using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.UpdateCurrency;

public sealed class UpdateCurrencyCommandHandler : ICommandHandler<UpdateCurrencyCommand, UpdateCurrencyCommandResponse>
{
    private readonly ICurrencyService _service;

    public UpdateCurrencyCommandHandler(ICurrencyService service)
    {
        _service = service;
    }

    public async Task<UpdateCurrencyCommandResponse> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
    {
        Currency currency = await _service.GetByIdAsync(request.CompanyId, request.Id);
        if (currency == null) throw new Exception(" CurrencyId bulunamadı");
    
        await _service.UpdateAsync(request);
        return new();
    }
}
