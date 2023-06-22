using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.CreateProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.RemoveProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.RemoveSoftProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.StateProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Commands.UpdateProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetAllProductTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTransactionFeatures.Queries.GetByIdProductTransaction;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.ProductTransaction;

public sealed class ProductTransactionController : ApiController
{
    public ProductTransactionController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProductTransactionCommand command)
    {
        CreateProductTransactionCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveProductTransactionCommand command)
    {
        RemoveProductTransactionCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(RemoveSoftProductTransactionCommand command)
    {
        RemoveSoftProductTransactionCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeState(StateProductTransactionCommand command)
    {
        StateProductTransactionCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateProductTransactionCommand command)
    {
        UpdateProductTransactionCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllProductTransactionQuery command)
    {
        PaginationResult<GetAllProductTransactionQueryResponse> response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetByIdProductTransactionQuery command)
    {
        GetByIdProductTransactionQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }

}
