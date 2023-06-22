using Microsoft.AspNetCore.Identity;
using QuickSalesApp.Application.Features.AppFeatures.UserFeatures.Commands.Create;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities.Identity;

namespace QuickSalesApp.Persistance.Services.AppServices;

public sealed class UserService : IUserService
{
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task CreateUser(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new AppUser
        {
            Id = Guid.NewGuid().ToString(),
            UserName = request.userName,
            Name = request.name,
            SurName = request.surName,
            Email = request.email,
            PhoneNumber = request.phoneNumber,
        };

        var result = await _userManager.CreateAsync(user, request.password);
        if (!result.Succeeded)
        {
            throw new Exception("hata oluştu");
        }


    }

    public async Task<AppUser> GetByUserName(string userName, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(userName);

        return user;

    }
    public async Task<AppUser> GetByEmail(string email, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(email);
        return user;
    }
}
