using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.CreateCurrency;

public sealed class CreateCurrencyCommandHandler : ICommandHandler<CreateCurrencyCommand, CreateCurrencyCommandResponse>
{
    private readonly ICurrencyService _service;

    public CreateCurrencyCommandHandler(ICurrencyService service)
    {
        _service = service;
    }

    public async Task<CreateCurrencyCommandResponse> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {

        Currency currency = await _service.GetByNameAsync(request.CompanyId, request.Name);
        if (currency != null) throw new Exception("Bu Kategori Daha önce kayıt edilmiş");

        await _service.CreateAsync(request, cancellationToken);

        return new();
    }
}
