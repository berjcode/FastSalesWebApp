using QuickSalesApp.Application.Messaging;

namespace QuickSalesApp.Application.Features.AppFeatures.UserFeatures.Commands.Create;

public sealed record CreateUserCommand(

    string userName,
    string name,
     string surName,
    string email,
   string phoneNumber,
     string password
   ) : ICommand<CreateUserCommandResponse>;
