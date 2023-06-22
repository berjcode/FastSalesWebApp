using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.UpdateBank;

public sealed class UpdateBankCommandHandler : ICommandHandler<UpdateBankCommand, UpdateBankCommandResponse>
{
    private readonly IBankService _bankService;

    public UpdateBankCommandHandler(IBankService bankService)
    {
        _bankService = bankService;
    }

    public async Task<UpdateBankCommandResponse> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
    {
        Bank bank= await _bankService.GetByIdAsync(request.CompanyId, request.Id);
        if (bank == null) throw new Exception("bu bank bulunamadı");

        
        await _bankService.UpdateAsync(request);
        return new();
    }
}
