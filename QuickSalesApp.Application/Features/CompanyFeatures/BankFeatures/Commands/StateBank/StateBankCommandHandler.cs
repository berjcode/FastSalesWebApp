using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.StateBank;

public sealed class StateBankCommandHandler : ICommandHandler<StateBankCommand, StateBankCommandResponse>
{
   private readonly IBankService _bankService;

    public StateBankCommandHandler(IBankService bankService)
    {
        _bankService = bankService;
    }

    public async Task<StateBankCommandResponse> Handle(StateBankCommand request, CancellationToken cancellationToken)
    {
        Bank bank= await _bankService.GetByIdAsync(request.CompanyId, request.BankId);
        if (bank == null) throw new Exception("Bu BankId Bulunamadı");

        bank.IsActive = request.IsActive;
        bank.UpdaterName = request.UpdaterName;
        bank.UpdateDate = DateTime.Now;

        Bank newBank = await _bankService.ChangeState(request.CompanyId, bank);
        return new();
    }
}
