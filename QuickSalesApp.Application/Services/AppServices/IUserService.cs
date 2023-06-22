

using QuickSalesApp.Application.Features.AppFeatures.UserFeatures.Commands.Create;
using QuickSalesApp.Domain.AppEntities.Identity;

namespace QuickSalesApp.Application.Services.AppServices;

public  interface IUserService
{
    Task CreateUser(CreateUserCommand request ,CancellationToken cancellationToken);

    Task<AppUser?> GetByUserName(string userName, CancellationToken cancellationToken);

    Task<AppUser?> GetByEmail(string email, CancellationToken cancellationToken);
}
