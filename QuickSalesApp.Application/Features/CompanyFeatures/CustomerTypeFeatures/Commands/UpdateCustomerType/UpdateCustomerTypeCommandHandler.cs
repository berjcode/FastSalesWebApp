using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;


namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.UpdateCustomerType;

public sealed class UpdateCustomerTypeCommandHandler : ICommandHandler<UpdateCustomerTypeCommand, UpdateCustomerTypeCommandResponse>
{
    private readonly ICustomerTypeService _customerTypeService;

    public UpdateCustomerTypeCommandHandler(ICustomerTypeService customerTypeService)
    {
        _customerTypeService = customerTypeService;
    }

    public async Task<UpdateCustomerTypeCommandResponse> Handle(UpdateCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        CustomerType customerType = await _customerTypeService.GetByIdAsync(request.CompanyId, request.Id);
        if (customerType == null) throw new Exception("bu customerType bulunamadı");

       
       
        await _customerTypeService.UpdateAsync(request);
        return new();
    }
}
