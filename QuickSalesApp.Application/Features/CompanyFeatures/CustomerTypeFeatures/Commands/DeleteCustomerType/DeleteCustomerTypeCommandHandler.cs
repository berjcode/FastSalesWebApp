using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;
namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.DeleteCustomerType;

public sealed class DeleteCustomerTypeCommandHandler : ICommandHandler<DeleteCustomerTypeCommand, DeleteCustomerTypeCommandResponse>
{
    private readonly ICustomerTypeService _customerTypeService;

    public DeleteCustomerTypeCommandHandler(ICustomerTypeService customerTypeService)
    {
        _customerTypeService = customerTypeService;
    }

    public async Task<DeleteCustomerTypeCommandResponse> Handle(DeleteCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        CustomerType customerType = await _customerTypeService.GetByIdAsync(request.CompanyId, request.CustomerTypeId);
        if (customerType == null) throw new Exception("Bu customer Bulunamadı");

        customerType.IsDelete = request.IsDelete;
        customerType.DeleterName = request.DeleterName;
        customerType.DeletedTime = DateTime.Now;

        CustomerType newCustomerType = await _customerTypeService.RemoveByIdSoft(request.CompanyId, customerType);
        return new();
    }
}
