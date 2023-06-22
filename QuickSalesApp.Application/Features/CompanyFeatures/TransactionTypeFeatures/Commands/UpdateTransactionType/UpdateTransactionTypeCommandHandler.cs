using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.UpdateTransactionType;

public sealed class UpdateTransactionTypeCommandHandler : ICommandHandler<UpdateTransactionTypeCommand, UpdateTransactionTypeCommandResponse>
{
    private readonly ITransactionTypeService _transactionTypeService;

    public UpdateTransactionTypeCommandHandler(ITransactionTypeService transactionTypeService)
    {
        _transactionTypeService = transactionTypeService;
    }

    public async Task<UpdateTransactionTypeCommandResponse> Handle(UpdateTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        TransactionType type = await _transactionTypeService.GetByIdAsync(request.Id, request.CompanyId);
        if (type == null) throw new Exception(ExceptionMessage.UpdateNotFoundException);

        await _transactionTypeService.UpdateAsync(request);
        return new();
    }
}
