using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.CreateCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.DeleteCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.RemoveCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.StateCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Commands.UpdateCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllActiveCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetAllFilterCustomerType;
using QuickSalesApp.Application.Features.CompanyFeatures.CustomerTypeFeatures.Queries.GetCustomerType;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.CustomerType;

public sealed class CustomerTypeController : ApiController
{
    public CustomerTypeController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        RemoveCustomerTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> Update(UpdateCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        UpdateCustomerTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> GetAll(GetAllCustomerTypeQuery request)
    {

        PaginationResult<GetAllCustomerTypeQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllActive(GetAllActiveCustomerTypeQuery request)
    {

        GetAllActiveCustomerTypeQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllFilter(GetAllFilterCustomerTypeQuery request)
    {

        PaginationResult<GetAllFilterCustomerTypeQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetCustomerTypeQuery request, CancellationToken cancellationToken)
    {
        GetCustomerTypeQueryResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> ChangeState(StateCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        StateCustomerTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);

    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(DeleteCustomerTypeCommand request, CancellationToken cancellationToken)
    {
        DeleteCustomerTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }
}
