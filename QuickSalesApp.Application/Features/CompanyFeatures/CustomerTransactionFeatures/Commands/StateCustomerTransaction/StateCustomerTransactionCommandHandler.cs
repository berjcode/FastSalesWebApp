using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.StateCustomerTransaction;

public sealed class StateCustomerTransactionCommandHandler : ICommandHandler<StateCustomerTransactionCommand, StateCustomerTransactionCommandResponse>
{
    private readonly ICustomerTransactionService _customerTransactionService;

    public StateCustomerTransactionCommandHandler(ICustomerTransactionService customerTransactionService)
    {
        _customerTransactionService = customerTransactionService;
    }

    public async Task<StateCustomerTransactionCommandResponse> Handle(StateCustomerTransactionCommand request, CancellationToken cancellationToken)
    {
        CustomerTransaction customerTransaction = await _customerTransactionService.GetByIdAsync(request.CompanyId, request.CustomerTransactionId);
        if (customerTransaction == null) throw new Exception("Bu customerTransaction Bulunamadı");

        customerTransaction.IsActive = request.IsActive;
        customerTransaction.UpdaterName = request.UpdaterName;
        customerTransaction.UpdateDate = DateTime.Now;

        CustomerTransaction newCustomerTransaction = await _customerTransactionService.ChangeState(request.CompanyId, customerTransaction);
        return new();
    }
}
