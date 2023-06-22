using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.RemoveDepartment;

public sealed class RemoveDepartmentCommandHandler : ICommandHandler<RemoveDepartmentCommand, RemoveDepartmentCommandResponse>
{
    private readonly IDepartmentService _departmentService;

    public RemoveDepartmentCommandHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<RemoveDepartmentCommandResponse> Handle(RemoveDepartmentCommand request, CancellationToken cancellationToken)
    {
        Department checkEntity = await _departmentService.GetByIdAsync(request.CompanyId, request.id);
        if (checkEntity == null) throw new Exception("Departman Bulunamadı");
        await _departmentService.RemoveByIdHard(request.CompanyId, request.id);

        return new();
    }
}
