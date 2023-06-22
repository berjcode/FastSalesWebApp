using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.CreateBankTransaction;

public sealed class CreateBankTransactionCommandHandler : ICommandHandler<CreateBankTransactionCommand, CreateBankTransactionCommandResponse>
{

    private readonly IBankTransactionService _bankTransactionService;

    public CreateBankTransactionCommandHandler(IBankTransactionService bankTransactionService)
    {
        _bankTransactionService = bankTransactionService;
    }

    public async Task<CreateBankTransactionCommandResponse> Handle(CreateBankTransactionCommand request, CancellationToken cancellationToken)
    {
        await _bankTransactionService.CreateAsync(request,cancellationToken);
        return new();
    }
}
