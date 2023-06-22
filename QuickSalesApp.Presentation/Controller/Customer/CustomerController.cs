using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.CreateCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.DeleteCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.RemoveCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.StateCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Commands.UpdateCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllFilterCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetAllGroupCodes;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetCustomer;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerFeatures.Queries.GetLastCode;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.Customer;

public sealed class CustomerController : ApiController
{
    public CustomerController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveCustomerCommand request, CancellationToken cancellationToken)
    {
        RemoveCustomerCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        UpdateCustomerCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllCustomerQuery request)
    {

        PaginationResult<GetAllCustomerQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllFilter(GetAllFilterCustomerQuery request)
    {

       PaginationResult< GetAllFilterCustomerQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        GetCustomerQueryResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> ChangeState(StateCustomerCommand request, CancellationToken cancellationToken)
    {
        StateCustomerCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);

    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        DeleteCustomerCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllGroupCodes(GetAllGroupCodesQuery request)
    {
        GetAllGroupCodesQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetLastCode(GetLastCodeQuery request)
    {
        GetLastCodeQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }
}
