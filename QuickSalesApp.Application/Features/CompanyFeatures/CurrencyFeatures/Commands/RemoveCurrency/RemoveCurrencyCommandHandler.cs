using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.RemoveCurrency;

public sealed class RemoveCurrencyCommandHandler : ICommandHandler<RemoveCurrencyCommand, RemoveCurrencyCommandResponse>
{
    private readonly ICurrencyService _service;

    public RemoveCurrencyCommandHandler(ICurrencyService service)
    {
        _service = service;
    }


    public async Task<RemoveCurrencyCommandResponse> Handle(RemoveCurrencyCommand request, CancellationToken cancellationToken)
    {
        Currency checkEntity = await _service.GetByIdAsync(request.CompanyId, request.id);
        if (checkEntity == null) throw new Exception("Currency Bulunamadı");
        await _service.RemoveByIdHard(request.CompanyId, request.id);

        return new();
    }
}
