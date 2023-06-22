using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.UpdateBankTransaction;

public sealed class UpdateBankTransactionCommandHandler : ICommandHandler<UpdateBankTransactionCommand, UpdateBankTransactionCommandResponse>
{

    private readonly IBankTransactionService _bankTransactionService;

    public UpdateBankTransactionCommandHandler(IBankTransactionService bankTransactionService)
    {
        _bankTransactionService = bankTransactionService;
    }
    public async Task<UpdateBankTransactionCommandResponse> Handle(UpdateBankTransactionCommand request, CancellationToken cancellationToken)
    {
        BankTransaction transaction = await _bankTransactionService.GetByIdAsync( request.CompanyId,request.BankTransactionId);
        if (transaction == null) throw new Exception("Bu hareket bulunamadı");

        await _bankTransactionService.UpdateAsync(request);
        return new();
    }
}
