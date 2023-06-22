using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
    public sealed record CreateCompanyCommand(
        string Name,
        string Address,
        string ServerName,
        string DatabaseName,
        string ServerUserId,
        string ServerPassword) : ICommand<CreateCompanyCommandResponse>;
}
