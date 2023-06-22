using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.UpdateUnit;

public sealed record UpdateUnitCommand(
        int Id,
        string Name,
        decimal Factor,
        bool IsDat,
        string UpdaterName,
        string CompanyId
    ) : ICommand<UpdateUnitCommandResponse>;