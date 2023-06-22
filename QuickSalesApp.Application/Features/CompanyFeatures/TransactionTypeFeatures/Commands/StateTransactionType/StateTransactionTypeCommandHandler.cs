using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Application.Utilities;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.StateTransactionType;

public sealed class StateTransactionTypeCommandHandler : ICommandHandler<StateTransactionTypeCommand,StateTransactionTypeCommandResponse>
{
    private readonly ITransactionTypeService _transactionTypeService;

    public StateTransactionTypeCommandHandler(ITransactionTypeService transactionTypeService)
    {
        _transactionTypeService = transactionTypeService;
    }

    public async Task<StateTransactionTypeCommandResponse> Handle(StateTransactionTypeCommand request, CancellationToken cancellationToken)
    {
        TransactionType type = await _transactionTypeService.GetByIdAsync(request.Id, request.CompanyId);
        if (type == null) throw new Exception(ExceptionMessage.NullDataException);

        type.IsActive = request.IsActive;
        type.DeleterName = request.DeleterName;
        type.DeletedTime = DateTime.Now;

        await _transactionTypeService.ChangeState(type, request.CompanyId);
        return new();
    }
}
