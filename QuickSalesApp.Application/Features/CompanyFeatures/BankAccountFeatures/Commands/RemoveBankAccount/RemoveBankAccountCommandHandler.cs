using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.RemoveBankAccount;

public sealed class RemoveBankAccountCommandHandler : ICommandHandler<RemoveBankAccountCommand, RemoveBankAccountCommandResponse>
{
    private readonly IBankAccountService _bankAccountService;

    public RemoveBankAccountCommandHandler(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public async Task<RemoveBankAccountCommandResponse> Handle(RemoveBankAccountCommand request, CancellationToken cancellationToken)
    {
        BankAccount checkEntity = await _bankAccountService.GetByIdAsync(request.CompanyId, request.BankAccountId);
        if (checkEntity == null) throw new Exception("BankAccountId Bulunamadı");
        await _bankAccountService.RemoveByIdHard(request.CompanyId, request.BankAccountId);

        return new();
    }
}
