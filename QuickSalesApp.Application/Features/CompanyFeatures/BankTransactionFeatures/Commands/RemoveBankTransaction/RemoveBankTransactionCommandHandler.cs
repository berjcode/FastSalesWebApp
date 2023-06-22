using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.RemoveBankTransaction;

public sealed class RemoveBankTransactionCommandHandler : ICommandHandler<RemoveBankTransactionCommand, RemoveBankTransactionCommandResponse>
{

    private readonly IBankTransactionService _bankTransactionService;

    public RemoveBankTransactionCommandHandler(IBankTransactionService bankTransactionService)
    {
        _bankTransactionService = bankTransactionService;
    }

    public async Task<RemoveBankTransactionCommandResponse> Handle(RemoveBankTransactionCommand request, CancellationToken cancellationToken)
    {
        BankTransaction transaction = await _bankTransactionService.GetByIdAsync(request.CompanyId, request.BankTransactionId);
        if (transaction == null) throw new Exception("Silmek istediğiniz haraket bulunamadı");

        await _bankTransactionService.RemoveByIdHard(request.CompanyId,request.BankTransactionId);
        return new();
    }
}
