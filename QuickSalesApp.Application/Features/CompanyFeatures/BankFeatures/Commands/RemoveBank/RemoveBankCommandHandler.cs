using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.RemoveBank;

public sealed class RemoveBankCommandHandler : ICommandHandler<RemoveBankCommand, RemoveBankCommandResponse>
{
    private readonly IBankService _bankService;

    public RemoveBankCommandHandler(IBankService bankService)
    {
        _bankService = bankService;
    }

    public async Task<RemoveBankCommandResponse> Handle(RemoveBankCommand request, CancellationToken cancellationToken)
    {
        Bank checkEntity = await _bankService.GetByIdAsync(request.CompanyId, request.id);
        if (checkEntity == null) throw new Exception("BankId Bulunamadı");
        await _bankService.RemoveByIdHard(request.CompanyId, request.id);

        return new();
    }
}
