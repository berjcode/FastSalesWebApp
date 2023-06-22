using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.StateCustomer;

public sealed class StateCustomerCommandHandler : ICommandHandler<StateCustomerCommand, StateCustomerCommandResponse>
{
     private readonly ICustomerService _customerService;

    public StateCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<StateCustomerCommandResponse> Handle(StateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer= await _customerService.GetByIdAsync(request.CompanyId, request.CustomerId);
        if (customer == null) throw new Exception("Bu customer Bulunamadı");

        customer.IsActive = request.IsActive;
        customer.UpdaterName = request.UpdaterName;
        customer.UpdateDate = DateTime.Now;

        Customer newCustomer = await _customerService.ChangeState(request.CompanyId, customer);
        return new();
    }
}
