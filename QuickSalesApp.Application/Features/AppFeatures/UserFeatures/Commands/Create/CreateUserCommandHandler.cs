using MediatR;
using Microsoft.AspNetCore.Identity;
using QuickSalesApp.Application.Messaging;
using QuickSalesApp.Application.Services.AppServices;
using QuickSalesApp.Domain.AppEntities.Identity;

namespace QuickSalesApp.Application.Features.AppFeatures.UserFeatures.Commands.Create;
public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserCommandResponse>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {

        var userResult = await _userService.GetByUserName(request.userName, cancellationToken);
        if (userResult != null) throw new Exception("Bu Kullanıcı Zaten Kayıtlı");
        var emailResult = await _userService.GetByEmail(request.email, cancellationToken);
        if (emailResult != null) throw new Exception("Bu Kullanıcı Zaten Kayıtlı");

        await _userService.CreateUser(request, cancellationToken);

        return new();
    }
}
