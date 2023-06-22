using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.DeleteCustomer;

public sealed class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand, DeleteCustomerCommandResponse>
{
    private readonly ICustomerService _customerService;

    public DeleteCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer= await _customerService.GetByIdAsync(request.CompanyId, request.CustomerId);
        if (customer == null) throw new Exception("Bu customer Bulunamadı");

        customer.IsDelete = request.IsDelete;
        customer.DeleterName = request.DeleterName;
        customer.DeletedTime = DateTime.Now;
        customer.IsActive = false;

        Customer newCustomer= await _customerService.RemoveByIdSoft(request.CompanyId, customer);
        return new();
    }
}
