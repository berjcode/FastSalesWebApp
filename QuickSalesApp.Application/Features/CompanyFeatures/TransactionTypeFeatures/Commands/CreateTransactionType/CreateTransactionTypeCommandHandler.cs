using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.CreateTransactionType;

public sealed class CreateTransactionTypeCommandHandler : ICommandHandler<CreateTransactionTypeCommand, CreateTransactionTypeCommandResponse>
{
    private readonly ITransactionTypeService _transactionTypeService;

    public CreateTransactionTypeCommandHandler(ITransactionTypeService transactionTypeService)
    {
        _transactionTypeService = transactionTypeService;
    }

    public async Task<CreateTransactionTypeCommandResponse> Handle(CreateTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        await _transactionTypeService.CreateAsync(request,cancellationToken);
        return new();
    }
}
