using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleAndUserRL.Commands.CreateMainRoleAndUserRL;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleAndUserRL.Commands.RemoveByIdMainRoleAndUserRl;
using QuickSalesApp.Application.Features.AppFeatures.UserAndCompanyRL.Commands.CreateRL;
using QuickSalesApp.Application.Features.AppFeatures.UserAndCompanyRL.Commands.RemoveByIdRL;
using QuickSalesApp.Presentation.Abstraction;

namespace QuickSalesApp.Presentation.Controller.Roles;

public sealed class MainRoleAndUserRelationshipController : ApiController
{
    public MainRoleAndUserRelationshipController(IMediator mediator) : base(mediator)
    {
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMainRoleAndUserRLCommand request, CancellationToken cancellationToken)
    {
        CreateMainRoleAndUserRLCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveByIdMainRoleAndUserRLCommand request, CancellationToken cancellationToken)
    {
        RemoveByIdMainRoleAndUserRlCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }

}
