using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.DeleteBankAccount;

public sealed class DeleteBankAccountCommandHandler : ICommandHandler<DeleteBankAccountCommand, DeleteBankAccountCommandResponse>
{

    private readonly IBankAccountService _bankAccountService;

    public DeleteBankAccountCommandHandler(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public async Task<DeleteBankAccountCommandResponse> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
    {
        BankAccount bankAccount = await _bankAccountService.GetByIdAsync(request.CompanyId, request.BankAccountId);
        if (bankAccount == null) throw new Exception("Bu BankId Bulunamadı");

        bankAccount.IsDelete = request.IsDelete;
        bankAccount.DeleterName = request.DeleterName;
        bankAccount.DeletedTime = DateTime.Now;

        BankAccount newBankAccount = await _bankAccountService.RemoveByIdSoft(request.CompanyId, bankAccount);
        return new();
    }
}
