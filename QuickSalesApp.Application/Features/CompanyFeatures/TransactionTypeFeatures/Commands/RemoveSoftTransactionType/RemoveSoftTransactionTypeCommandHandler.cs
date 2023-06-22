using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.RemoveSoftTransactionType;

public sealed class RemoveSoftTransactionTypeCommandHandler : ICommandHandler<RemoveSoftTransactionTypeCommand, RemoveSoftTransactionTypeCommandResponse>
{
    private readonly ITransactionTypeService _transactionTypeService;

    public RemoveSoftTransactionTypeCommandHandler(ITransactionTypeService transactionTypeService)
    {
        _transactionTypeService = transactionTypeService;
    }

    public async Task<RemoveSoftTransactionTypeCommandResponse> Handle(RemoveSoftTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        TransactionType type = await _transactionTypeService.GetByIdAsync(request.id, request.CompanyId);
        if (type == null) throw new Exception(ExceptionMessage.DeleteNotFoundException);

        await _transactionTypeService.RemoveByIdSoft(request.CompanyId, request.id);
        return new();
    }
}
