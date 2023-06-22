using MediatR;
using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed record MigrateCompanyDatabaseCommand()
        : ICommand<MigrateCompanyDatabaseCommandResponse>;
}
