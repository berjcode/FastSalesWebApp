using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.CreateBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.DeleteBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.RemoveBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.StateBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Commands.UpdateBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetAllBank;
using QuickSalesApp.Application.Features.CompanyFeatures.BankFeatures.Queries.GetBank;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.Bank;
public sealed class BankController : ApiController
{
    public BankController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateBankCommand request, CancellationToken cancellationToken)
    {
        CreateBankCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveBankCommand request, CancellationToken cancellationToken)
    {
        RemoveBankCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> Update(UpdateBankCommand request, CancellationToken cancellationToken)
    {
        UpdateBankCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> GetAll(GetAllBankQuery request)
    {

        PaginationResult<GetAllBankQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetBankQuery request, CancellationToken cancellationToken)
    {
        GetBankQueryResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> ChangeState(StateBankCommand request, CancellationToken cancellationToken)
    {
        StateBankCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);

    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(DeleteBankCommand request, CancellationToken cancellationToken)
    {
        DeleteBankCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }
}
