using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.CreateCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.DeleteCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.RemoveCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.StateCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Commands.UpdateCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetAllFilterCustomerTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTransactionFeatures.Queries.GetCustomerTransaction;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.CustomerTransaction;

public sealed class CustomerTransactionController : ApiController
{
    public CustomerTransactionController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCustomerTransactionCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerTransactionCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveCustomerTransactionCommand request, CancellationToken cancellationToken)
    {
        RemoveCustomerTransactionCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateCustomerTransactionCommand request, CancellationToken cancellationToken)
    {
        UpdateCustomerTransactionCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllByFilter(GetAllFilterCustomerTransactionQuery request)
    {

        PaginationResult<GetAllFilterCustomerTransactionQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetCustomerTransactionQuery request, CancellationToken cancellationToken)
    {
        GetCustomerTransactionQueryResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> ChangeState(StateCustomerTransactionCommand request, CancellationToken cancellationToken)
    {
        StateCustomerTransactionCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);

    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(DeleteCustomerTransactionCommand request, CancellationToken cancellationToken)
    {
        DeleteCustomerTransactionCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }

}
