using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.DeleteDepartment;

public sealed  record DeleteDepartmentCommand(
    string CompanyId,
    int DepartmentId,
    bool IsDelete,
    string DeleterName
    ) :ICommand<DeleteCustomerCommandResponse>;


