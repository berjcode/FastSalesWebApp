using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
namespace QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.DeleteCurrency;

public sealed class DeleteCurrencyCommandHandler : ICommandHandler<DeleteCurrencyCommand, DeleteCurrencyCommandResponse>
{
    private readonly ICurrencyService _service;

    public DeleteCurrencyCommandHandler(ICurrencyService service)
    {
        _service = service;
    }

    public async Task<DeleteCurrencyCommandResponse> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
    {
        Currency currency= await _service.GetByIdAsync(request.CompanyId, request.CurrencyId);
        if (currency == null) throw new Exception("Bu currency Bulunamadı");

        currency.IsDelete = request.IsDelete;
        currency.DeleterName = request.DeleterName;
        currency.DeletedTime = DateTime.Now;

        Currency newCurrency = await _service.RemoveByIdSoft(request.CompanyId, currency);
        return new();
    }
}
