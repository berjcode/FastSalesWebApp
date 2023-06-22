using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.StateBankAccount;

public sealed class StateBankAccountCommandHandler : ICommandHandler<StateBankAccountCommand, StateBankAccountCommandResponse>
{
    private readonly IBankAccountService _bankAccountService;

    public StateBankAccountCommandHandler(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public async Task<StateBankAccountCommandResponse> Handle(StateBankAccountCommand request, CancellationToken cancellationToken)
    {
        BankAccount bankAccount = await _bankAccountService.GetByIdAsync(request.CompanyId, request.BankAccountId);
        if (bankAccount == null) throw new Exception("Bu bankAccountId Bulunamadı");

        bankAccount.IsActive = request.IsActive;
        bankAccount.UpdaterName = request.UpdaterName;
        bankAccount.UpdateDate = DateTime.Now;

        BankAccount newBank = await _bankAccountService.ChangeState(request.CompanyId, bankAccount);
        return new();
    }
}
