using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.RemoveTransactionType;

public sealed class RemoveTransactionTypeCommandHandler : ICommandHandler<RemoveTransactionTypeCommand, RemoveTransactionTypeCommandResponse>
{
    private readonly ITransactionTypeService _transactionTypeService;

    public RemoveTransactionTypeCommandHandler(ITransactionTypeService transactionTypeService)
    {
        _transactionTypeService = transactionTypeService;
    }

    public async Task<RemoveTransactionTypeCommandResponse> Handle(RemoveTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        TransactionType type = await _transactionTypeService.GetByIdAsync(request.id, request.CompanyId);
        if (type == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _transactionTypeService.RemoveByIdHard(request);
        return new();
    }
}
