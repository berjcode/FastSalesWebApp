using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.CreatePersonal;

public sealed record CreatePersonalCommand(
        string Code,
        string Name,
        string Adress1,
        string Adress2,
        string CellPhone1,
        string CellPhone2,
        string Telephone,
        string Email,
        int DepartmentId,
        string CompanyId

    ) : ICommand<CreatePersonalCommandResponse>;
