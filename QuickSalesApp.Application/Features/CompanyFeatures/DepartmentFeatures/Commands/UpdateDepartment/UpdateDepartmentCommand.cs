using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.UpdateDepartment;
public sealed  record UpdateDepartmentCommand  (string CompanyId,
    int Id,
    string Name,
    string UpdaterName

    ): ICommand<UpdateDepartmentCommandResponse>;
