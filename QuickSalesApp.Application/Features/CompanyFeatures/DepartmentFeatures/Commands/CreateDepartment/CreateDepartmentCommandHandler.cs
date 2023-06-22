using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.CompanyService;
using QuickSalesApp.Domain.AppEntities.CompanyEntities;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.CreateDepartment;

public sealed class CreateDepartmentCommandHandler : ICommandHandler<CreateDepartmentCommand, CreateDepartmentCommandResponse>
{

    private readonly IDepartmentService _departmentService;

    public CreateDepartmentCommandHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommand request,
        CancellationToken cancellationToken)
    {
        Department department = await _departmentService.GetByNameAsync(request.CompanyId, request.name);
        if (department != null) throw new Exception("Bu departman daha önce tanımlanmıştır");
     
        await _departmentService.CreateAsync(request, cancellationToken);
        return new();
    }
}
