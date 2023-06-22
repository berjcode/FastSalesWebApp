using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.CreateProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.RemoveProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.RemoveSoftProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.StateProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Commands.UpdateProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllByFilterProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetAllProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetByIdProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetByNameProduct;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductFeatures.Queries.GetProductLastCode;
using QuickSalesApp.Presentation.Abstraction;

namespace QuickSalesApp.Presentation.Controller.Product;

public sealed class ProductController : ApiController
{
    public ProductController(IMediator mediator) : base(mediator)
    {
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        CreateProductCommandResponse response = await _mediator.Send(command);
        return Ok(response);    
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeState(StateProductCommand command)
    {
        StateProductCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveProductCommand command)
    {
        RemoveProductCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(RemoveSoftProductCommand command)
    {
        RemoveSoftProductCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateProductCommand command)
    {
        UpdateProductCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllProductQuery command)
    {
        PaginationResult<GetAllProductQueryResponse> response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetById(GetByIdProductQuery command)
    {
        GetByIdProductQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetByName(GetByNameProductQuery command)
    {
        GetByNameProductQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllFilter(GetAllByFilterProductQuery request)
    {

        PaginationResult<GetAllByFilterProductQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> GetLastProductCode(GetProductLastCodeQuery command)
    {
        GetProductLastCodeQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }

}
