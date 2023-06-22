using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.CreateMainRole;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.CreateMainRoleRL;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.RemoveByIdMainRoleRL;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Commands.RemoveMainRoleRL;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleandRole.Queries.GetAllMainRoleRL;
using QuickSalesApp.Presentation.Abstraction;

namespace QuickSalesApp.Presentation.Controller.Roles;

public sealed class MainRoleAndRoleRelationshipController : ApiController
{
    public MainRoleAndRoleRelationshipController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        GetAllMainRoleAndRoleRLQuery request = new();
        GetAllMainRoleAndRoleRLQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMainRoleAndRoleRLCommand request)
    {
        CreateMainRoleAndRoleRLCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveByIdMainRoleAndRoleRlCommand request)
    {
        RemoveByIdMainRoleAndRoleRlCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }


    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,GET,OPTIONS");
        return Ok();
    }
}
