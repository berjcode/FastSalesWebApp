using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.StateCustomerType;

public sealed class StateCustomerTypeCommandHandler : ICommandHandler<StateCustomerTypeCommand, StateCustomerTypeCommandResponse>
{
    private readonly ICustomerTypeService _customerTypeService;

    public StateCustomerTypeCommandHandler(ICustomerTypeService customerTypeService)
    {
        _customerTypeService = customerTypeService;
    }

    public async Task<StateCustomerTypeCommandResponse> Handle(StateCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        CustomerType customerType = await _customerTypeService.GetByIdAsync(request.CompanyId, request.CustomerTypeId);
        if (customerType == null) throw new Exception("Bu Kategori Bulunamadı");

        customerType.IsActive = request.IsActive;
        customerType.UpdaterName = request.UpdaterName;
        customerType.UpdateDate = DateTime.Now;

        CustomerType newCustomerType = await _customerTypeService.ChangeState(request.CompanyId, customerType);
        return new();
    }
}
