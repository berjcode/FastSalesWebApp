using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.StateDepartment;

public sealed record StateDepartmentCommand(
    string CompanyId,
    int DepartmanId,
    bool IsActive,
    string UpdaterName

    ) :ICommand<StateDepartmentCommandResponse>;
