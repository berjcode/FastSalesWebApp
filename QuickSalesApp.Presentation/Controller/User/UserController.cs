
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.AppFeatures.UserFeatures.Commands.Create;
using QuickSalesApp.Presentation.Abstraction;

namespace QuickSalesApp.Presentation.Controller.User;

public sealed class UserController : ApiController
{
    public UserController(IMediator mediator) : base(mediator)
    {
    }




    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken cancellationToken)
    {
        CreateUserCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);    
    }


    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }
}
