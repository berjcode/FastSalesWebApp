using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.DeleteBankTransaction;

public sealed class DeleteBankTransactionHandler : ICommandHandler<DeleteBankTransactionCommand, DeleteBankTransactionResponse>
{

    private readonly IBankTransactionService _bankTransactionService;

    public DeleteBankTransactionHandler(IBankTransactionService bankTransactionService)
    {
        _bankTransactionService = bankTransactionService;
    }

    public async Task<DeleteBankTransactionResponse> Handle(DeleteBankTransactionCommand request, CancellationToken cancellationToken)
    {
        BankTransaction transaction = await _bankTransactionService.GetByIdAsync(request.CompanyId, request.BankTransactionId);
        if (transaction == null) throw new Exception("Silmek istediğiniz haraket bulunamadı");

        await _bankTransactionService.RemoveByIdSoft(request.CompanyId, transaction);
        return new();
    }
}
