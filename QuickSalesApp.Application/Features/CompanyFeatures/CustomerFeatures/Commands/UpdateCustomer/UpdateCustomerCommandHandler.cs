using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.UpdateCustomer;
public sealed class UpdateCustomerCommandHandler : ICommandHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
{
    private readonly ICustomerService _customerService;

    public UpdateCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        Customer customer = await _customerService.GetByIdAsync(request.CompanyId, request.Id);
        if (customer == null) throw new Exception("bu customer bulunamadı");


        await _customerService.UpdateAsync(request);
        return new();
    }
}
