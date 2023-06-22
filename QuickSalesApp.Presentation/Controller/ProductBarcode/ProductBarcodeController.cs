using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.CreateProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.RemoveProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.RemoveSoftProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.StateProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Commands.UpdateProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllBasketProductbyBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllByFilterProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetAllProductBarcode;
using QuickSalesApp.Application.Features.CompanyFeatures.ProductBarcodeFeatures.Queries.GetByIdProductBarcode;
using QuickSalesApp.Presentation.Abstraction;
using System.Threading;


namespace QuickSalesApp.Presentation.Controller.ProductBarcode;

public sealed class ProductBarcodeController : ApiController
{
    public ProductBarcodeController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProductBarcodeCommand command)
    {
        CreateProductBarcodeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveProductBarcodeCommand command)
    {
        RemoveProductBarcodeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(RemoveSoftProductBarcodeCommand command)
    {
        RemoveSoftProductBarcodeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeState(StateProductBarcodeCommand command)
    {
        StateProductBarcodeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateProductBarcodeCommand command)
    {
        UpdateProductBarcodeCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllProductBarcodeQuery command)
    {
        PaginationResult<GetAllProductBarcodeQueryResponse> response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetByIdProductBarcodeQuery command)
    {
        GetByIdProductBarcodeQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllFilter(GetAllByFilterProductBarcodeQuery request)
    {

        PaginationResult<GetAllByFilterProductBarcodeQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> GetBasketProductByBarcode (GetAllBasketProductbyBarcodeQuery request)
    {
        GetAllBasketProductbyBarcodeQueryResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }




}
