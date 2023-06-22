using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.DeleteDepartment;

public sealed class DeleteCustomerCommandHandler : ICommandHandler<DeleteDepartmentCommand, DeleteCustomerCommandResponse>
{
    private readonly IDepartmentService _service;

    public DeleteCustomerCommandHandler(IDepartmentService service)
    {
        _service = service;
    }

    public async Task<DeleteCustomerCommandResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        Department department = await _service.GetByIdAsync(request.CompanyId, request.DepartmentId);
        if (department == null) throw new Exception("Bu departman Bulunamadı");

        department.IsDelete = request.IsDelete;
        department.DeleterName = request.DeleterName;
        department.DeletedTime = DateTime.Now;

        Department newDepartment = await _service.RemoveByIdSoft(request.CompanyId, department);
        return new();
    }
}
