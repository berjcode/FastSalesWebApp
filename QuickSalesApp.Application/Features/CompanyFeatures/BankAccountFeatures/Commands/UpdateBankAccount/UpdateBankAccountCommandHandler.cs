using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.UpdateBankAccount;

public sealed class UpdateBankAccountCommandHandler : ICommandHandler<UpdateBankAccountCommand, UpdateBankAccountCommandResponse>
{
    private readonly IBankAccountService _bankAccountService;

    public UpdateBankAccountCommandHandler(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public async Task<UpdateBankAccountCommandResponse> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
    {
        BankAccount bank = await _bankAccountService.GetByIdAsync(request.CompanyId, request.Id);
        if (bank == null) throw new Exception("bu BankAccount bulunamadı");


        await _bankAccountService.UpdateAsync(request);
        return new();
    }
}
