using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.CreateBankAccount;

public sealed class CreateBankAccountCommandHandler : ICommandHandler<CreateBankAccountCommand, CreateBankAccountCommandResponse>
{
    private readonly IBankAccountService _bankAccountService;

    public CreateBankAccountCommandHandler(IBankAccountService bankAccountService)
    {
        _bankAccountService = bankAccountService;
    }

    public async Task<CreateBankAccountCommandResponse> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
    {
        //BankAccount bankAccount = await _bankAccountService.GetByNameAsync(request.CompanyId, request.Name);
        //if (bankAccount != null) throw new Exception("Bu bankAccount Daha önce kayıt edilmiş");

        await _bankAccountService.CreateAsync(request, cancellationToken);

        return new();
    }
}
