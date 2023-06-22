using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.CreateTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.RemoveSoftTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.RemoveTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.StateTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Commands.UpdateTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetAllTransactionType;
using QuickSalesApp.Application.Features.CompanyFeatures.TransactionTypeFeatures.Queries.GetTransactionType;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.TransactionType;

public sealed class TransactionTypeController : ApiController
{
    public TransactionTypeController(IMediator mediator) : base(mediator)
    {
    }



    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateTransactionTypeCommand command)
    {
        CreateTransactionTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveTransactionTypeCommand command)
    {
        RemoveTransactionTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(RemoveSoftTransactionTypeCommand command)
    {
        RemoveSoftTransactionTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeState(StateTransactionTypeCommand command)
    {
        StateTransactionTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateTransactionTypeCommand command)
    {
        UpdateTransactionTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllTransactionTypeQuery command)
    {
        PaginationResult<GetAllTransactionTypeQueryResponse> response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetTransactionTypeQuery command)
    {
        GetTransactionTypeQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }
}
