using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.CreateAllRole;
using QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.CreateRole;
using QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.DeleteRole;
using QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Commands.UpdateRole;
using QuickSalesApp.Application.Features.AppFeatures.RoleFeatures.Queryies.GetAllRoles;
using QuickSalesApp.Presentation.Abstraction;

namespace QuickSalesApp.Presentation.Controller.Role;

public sealed class RolesController : ApiController
{
    public RolesController(IMediator mediator) : base(mediator)
    {
    }



    [HttpPost("[action]")]

    public async Task<IActionResult> Create(CreateRoleCommand request)
    {
        CreateRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAll()
    {
        GetAllRolesQuery request = new();
        GetAllRolesQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateRoleCommand request)
    {
        UpdateRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }


    [HttpGet("[action]/{id}")]

    public async Task<IActionResult>  Remove(string id)
    {
        DeleteRoleCommand request = new(id);

        DeleteRoleCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> CreateAllRoles()
    {
        CreateAllRolesCommand request = new();
        CreateAllRolesCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,GET,OPTIONS");
        return Ok();
    }
}
