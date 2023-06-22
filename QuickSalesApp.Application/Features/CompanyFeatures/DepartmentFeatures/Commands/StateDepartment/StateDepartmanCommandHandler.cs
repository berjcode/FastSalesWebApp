using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.StateDepartment;

public sealed class StateDepartmanCommandHandler : ICommandHandler<StateDepartmentCommand, StateDepartmentCommandResponse>
{
    private readonly IDepartmentService _service;

    public StateDepartmanCommandHandler(IDepartmentService service)
    {
        _service = service;
    }

    public async Task<StateDepartmentCommandResponse> Handle(StateDepartmentCommand request, CancellationToken cancellationToken)
    {
        Department department = await _service.GetByIdAsync(request.CompanyId, request.DepartmanId);
        if (department == null) throw new Exception("Bu Kategori Bulunamadı");

        department.IsActive = request.IsActive;
        department.UpdaterName = request.UpdaterName;
        department.UpdateDate = DateTime.Now;

        Department newDepartment = await _service.ChangeState(request.CompanyId, department);
        return new();
    }
}
