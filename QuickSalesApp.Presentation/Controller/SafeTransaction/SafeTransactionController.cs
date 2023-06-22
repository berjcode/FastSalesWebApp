using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.CreateSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.RemoveSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.RemoveSoftSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.StateSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Commands.UpdateSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetAllSafeTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.SafeTransactionFeatures.Queries.GetSafeTransaction;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.SafeTransaction;

public sealed class SafeTransactionController : ApiController
{
    public SafeTransactionController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateSafeTransactionCommand command)
    {
        CreateSafeTransactionCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveSafeTransactionCommand command)
    {
        RemoveSafeTransactionCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(RemoveSoftSafeTransactionCommand command)
    {
        RemoveSoftSafeTransactionCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeState(StateSafeTransactionCommand command)
    {
        StateSafeTransactionCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateSafeTransactionCommand command)
    {
        UpdateSafeTransactionCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllSafeTransactionQuery command)
    {
        PaginationResult<GetAllSafeTransactionQueryResponse> response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetSafeTransactionQuery command)
    {
        GetSafeTransactionQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }
}
