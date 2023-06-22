using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.CreateProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.RemoveProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.RemoveSoftProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.StateProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Commands.UpdateProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetAllProductType;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductTypeFeatures.Queries.GetByIdProductType;
using QuickSalesApp.Presentation.Abstraction;

namespace QuickSalesApp.Presentation.Controller.ProductType;

public sealed class ProductTypeController : ApiController
{
    public ProductTypeController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProductTypeCommand command)
    {
        CreateProductTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveProductTypeCommand command)
    {
        RemoveProductTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(RemoveSoftProductTypeCommand command)
    {
        RemoveSoftProductTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeState(StateProductTypeCommand command)
    {
        StateProductTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateProductTypeCommand command)
    {
        UpdateProductTypeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllProductTypeQuery command)
    {
        PaginationResult<GetAllProductTypeQueryResponse> response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetByIdProductTypeQuery command)
    {
        GetByIdProductTypeQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }
    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }

}
