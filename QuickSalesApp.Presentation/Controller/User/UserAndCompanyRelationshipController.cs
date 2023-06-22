
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.AppFeatures.UserAndCompanyRL.Commands.CreateRL;
using QuickSalesApp.Application.Features.AppFeatures.UserAndCompanyRL.Commands.RemoveByIdRL;
using QuickSalesApp.Presentation.Abstraction;

namespace QuickSalesApp.Presentation.Controller.User;

public sealed class UserAndCompanyRelationshipController : ApiController
{
    public UserAndCompanyRelationshipController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> Create(CreateUserAndCompanyRLCommand request, CancellationToken cancellationToken)
    {
        CreateUserAndCompanyRLCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("[action]")]

    public async Task<IActionResult> RemoveById(RemoveByIdUserAndCompanyRLCommand request)
    {
        RemoveByIdUserAndCompanyRLCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }

}
