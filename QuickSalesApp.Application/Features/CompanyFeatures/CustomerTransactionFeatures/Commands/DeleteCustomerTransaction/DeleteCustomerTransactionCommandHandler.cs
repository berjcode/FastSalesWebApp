using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.DeleteCustomerTransaction;

public sealed class DeleteCustomerTransactionCommandHandler : ICommandHandler<DeleteCustomerTransactionCommand, DeleteCustomerTransactionCommandResponse>
{
    private readonly ICustomerTransactionService _customerTransactionService;

    public DeleteCustomerTransactionCommandHandler(ICustomerTransactionService customerTransactionService)
    {
        _customerTransactionService = customerTransactionService;
    }

    public async Task<DeleteCustomerTransactionCommandResponse> Handle(DeleteCustomerTransactionCommand request, CancellationToken cancellationToken)
    {
        CustomerTransaction customerTransaction = await _customerTransactionService.GetByIdAsync(request.CompanyId, request.CustomerTransactionId);
        if (customerTransaction == null) throw new Exception("Bu customerTransaction Bulunamadı");

        customerTransaction.IsDelete = request.IsDelete;
        customerTransaction.DeleterName = request.DeleterName;
        customerTransaction.DeletedTime = DateTime.Now;

        CustomerTransaction newcustomerTransaction = await _customerTransactionService.RemoveByIdSoft(request.CompanyId, customerTransaction);
        return new();
    }
}
