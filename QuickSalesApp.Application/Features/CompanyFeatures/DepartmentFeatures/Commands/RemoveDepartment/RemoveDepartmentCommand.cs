

using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.RemoveDepartment;

public sealed record RemoveDepartmentCommand(int id,
    string CompanyId) : ICommand<RemoveDepartmentCommandResponse>;
