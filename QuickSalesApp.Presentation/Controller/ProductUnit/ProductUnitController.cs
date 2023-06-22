using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.CreateProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.RemoveProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.RemoveSoftProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.StateProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Commands.UpdateProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllByFilterProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllForProductList;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetAllProductUnit;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductUnitFeatures.Queries.GetByIdProductUnit;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.ProductUnit;

public sealed class ProductUnitController : ApiController
{
    public ProductUnitController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProductUnitCommand command)
    {
        CreateProductUnitCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveProductUnitCommand command)
    {
        RemoveProductUnitCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(RemoveSoftProductUnitCommand command)
    {
        RemoveSoftProductUnitCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeState(StateProductUnitCommand command)
    {
        StateProductUnitCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateProductUnitCommand command)
    {
        UpdateProductUnitCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllProductUnitQuery command)
    {
        PaginationResult<GetAllProductUnitQueryResponse> response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetByIdProductUnitQuery command)
    {
        GetByIdProductUnitQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllFilter(GetAllByFilterProductUnitQuery request)
    {

        PaginationResult<GetAllByFilterProductUnitQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllForProduct(GetAllForProductListQuery request)
    {

        PaginationResult<GetAllForProductListQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }

}
