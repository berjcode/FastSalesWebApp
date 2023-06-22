using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateAllMainRoles;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateRole;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.RemoveMainRole;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Commands.UpdateMainRole;
using QuickSalesApp.Application.Features.AppFeatures.MainRoleFeatures.Queries;
using QuickSalesApp.Presentation.Abstraction;

namespace QuickSalesApp.Presentation.Controller.Roles;

public sealed class MainRolesController : ApiController
{
    public MainRolesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateMainRoleCommand request)
    {
        CreateMainRoleResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateAllMainRole(CancellationToken cancellationToken)
    {
        CreateAllMainRolesCommand request = new(null);
        CreateAllMainRolesResponse response = await _mediator.Send(request,cancellationToken);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        GetAllMainRoleQuery request = new();
        GetAllMainRoleQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveMainRoleCommand request)
    {
        RemoveMainRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);    
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateMainRoleCommand request)
    {
       UpdateMainRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,GET,OPTIONS");
        return Ok();
    }

}
