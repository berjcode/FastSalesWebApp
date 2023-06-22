using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.CreateBank;

public sealed class CreateBankCommandHandler : ICommandHandler<CreateBankCommand, CreateBankCommandResponse>
{
    private readonly IBankService _bankService;

    public CreateBankCommandHandler(IBankService bankService)
    {
        _bankService = bankService;
    }

    public async Task<CreateBankCommandResponse> Handle(CreateBankCommand request, CancellationToken cancellationToken)
    {

        Bank bank = await _bankService.GetByNameAsync(request.CompanyId, request.Name);
        if (bank != null) throw new Exception("Bu bank Daha önce kayıt edilmiş");

        await _bankService.CreateAsync(request, cancellationToken);

        return new();
    }
}
