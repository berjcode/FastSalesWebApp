using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.CreateUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.RemoveSoftUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.RemoveUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.StateUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Commands.UpdateUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllActiveUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllFilterUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetAllUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetBasketUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.UnitFeatures.Queries.GetUnit;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.Unit;

public sealed class UnitController : ApiController
{
    public UnitController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUnitCommand command)
    {
        CreateUnitCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveUnitCommand command)
    {
        RemoveUnitCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(RemoveSoftUnitCommand command)
    {
        RemoveSoftUnitCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeState(StateUnitCommand command)
    {
        StateUnitCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateUnitCommand command)
    {
        UpdateUnitCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }
      
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllActive(GetAllActiveUnitQuery command)
    {
        PaginationResult<GetAllActiveUnitQueryResponse> response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllUnitQuery command)
    {
        PaginationResult<GetAllUnitQueryResponse> response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllBasketUnit(GetBasketUnitQuery command)
    {
        GetBasketUnitQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetUnitQuery command)
    {
        GetUnitQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> GetAllFilter(GetAllFilterUnitQuery request)
    {

        PaginationResult<GetAllFilterUnitQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }

}