using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.UpdatePersonal;

public sealed record UpdatePersonalCommand(
    int Id,
    string Code,
    string Name,
    string Adress1,
    string Adress2,
    string CellPhone1,
    string CellPhone2,
    string Telephone,
    string Email,
    int DepartmentId,
    string CompanyId,
    string UpdaterName
) : ICommand<UpdatePersonalCommandResponse>;
