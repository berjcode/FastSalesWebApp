using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.CreateCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.DeleteCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.RemoveCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.StateCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Commands.UpdateCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Queries.GetAllCurrency;
using QuickSalesApp.Application.Features.CompanyFeatures.CurrencyFeatures.Queries.GetCurrency;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.Currency;

public sealed class CurrencyController : ApiController
{
    public CurrencyController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCurrencyCommand request, CancellationToken cancellationToken)
    {
        CreateCurrencyCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveCurrencyCommand request, CancellationToken cancellationToken)
    {
        RemoveCurrencyCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> Update(UpdateCurrencyCommand request, CancellationToken cancellationToken)
    {
        UpdateCurrencyCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> GetAll(GetAllCurrencyQuery request)
    {

        PaginationResult<GetAllCurrencyQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetCurrencyQuery request, CancellationToken cancellationToken)
    {
        GetCurrencyQueryResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> ChangeState(StateCurrencyCommand request, CancellationToken cancellationToken)
    {
        StateCurrencyCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);

    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(DeleteCurrencyCommand request, CancellationToken cancellationToken)
    {
        DeleteCurrencyCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }

}
