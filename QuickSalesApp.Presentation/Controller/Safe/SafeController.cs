using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.CreateSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.RemoveSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.RemoveSoftSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.StateSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Commands.UpdateSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetAllSafe;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeFeatures.Queries.GetByIdSafe;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.Safe;

public sealed class SafeController : ApiController
{
    public SafeController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateSafeCommand command)
    {
        CreateSafeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveSafeCommand command)
    {
        RemoveSafeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(RemoveSoftSafeCommand command)
    {
        RemoveSoftSafeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeState(StateSafeCommand command)
    {
        StateSafeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateSafeCommand command)
    {
        UpdateSafeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllSafeQuery command)
    {
        PaginationResult<GetAllSafeQueryResponse> response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetByIdSafeQuery command)
    {
        GetByIdSafeQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }


}
