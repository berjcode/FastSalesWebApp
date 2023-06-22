using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.StateBankTransaction;

public sealed class StateBankTransactionCommandHandler : ICommandHandler<StateBankTransactionCommand, StateBankTransactionCommandResponse>
{

    private readonly IBankTransactionService _bankTransactionService;

    public StateBankTransactionCommandHandler(IBankTransactionService bankTransactionService)
    {
        _bankTransactionService = bankTransactionService;
    }
    public async Task<StateBankTransactionCommandResponse> Handle(StateBankTransactionCommand request, CancellationToken cancellationToken)
    {
        BankTransaction transaction = await _bankTransactionService.GetByIdAsync(request.CompanyId, request.BankTransactionId);
        if (transaction == null) throw new Exception("State Değiştirildi.");

        transaction.IsActive = request.IsActive;
        transaction.UpdaterName = request.UpdaterName;
        transaction.UpdateDate = DateTime.Now;

        await _bankTransactionService.ChangeState(request.CompanyId, transaction);
        return new();
    }
}
