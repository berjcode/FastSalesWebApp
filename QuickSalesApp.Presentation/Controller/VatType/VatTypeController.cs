using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.CreateVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.RemoveSoftVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.RemoveVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.StateVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Commands.UpdateVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllActiveVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllFilterVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetAllVatType;
using QuickSalesApp.Application.Features.CompanyFeatures.VatTypeFeatures.Queries.GetVatType;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.VatType;

public sealed class VatTypeController : ApiController
{
    public VatTypeController(IMediator mediator) : base(mediator)
    {
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateVatTypeCommand command)
    {
        CreateVatTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveVatTypeCommand command)
    {
        RemoveVatTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(RemoveSoftVatTypeCommand command)
    {
        RemoveSoftVatTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeState(StateVatTypeCommand command)
    {
        StateVatTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateVatTypeCommand command)
    {
        UpdateVatTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllVatTypeQuery command)
    {
        PaginationResult<GetAllVatTypeQueryResponse> response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllActive(GetAllActiveVatTypeQuery command)
    {
        PaginationResult<GetAllActiveVatTypeQueryResponse> response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetVatTypeQuery command)
    {
        GetVatTypeQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }
    [HttpPost("[action]")]

    public async Task<IActionResult> GetAllFilter(GetAllFilterVatTypeQuery request)
    {

        PaginationResult<GetAllFilterVatTypeQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }

}
