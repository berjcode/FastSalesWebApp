using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.UpdateDepartment;

public sealed class UpdateCustomerCommandHandler : ICommandHandler<UpdateDepartmentCommand, UpdateDepartmentCommandResponse>
{
    private readonly IDepartmentService _departmentService;

    public UpdateCustomerCommandHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<UpdateDepartmentCommandResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        Department department = await _departmentService.GetByIdAsync(request.CompanyId, request.Id);
        if (department == null) throw new Exception("bu departman bulunamadı");


        await _departmentService.UpdateAsync(request);
        return new();
    }
}
