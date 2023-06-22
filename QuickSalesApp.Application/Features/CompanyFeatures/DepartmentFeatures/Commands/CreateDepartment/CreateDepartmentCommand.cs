using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.CreateDepartment;

public sealed record CreateDepartmentCommand(
    string name ,
    string creatorName,
    string CompanyId
    ) : ICommand<CreateDepartmentCommandResponse>;

