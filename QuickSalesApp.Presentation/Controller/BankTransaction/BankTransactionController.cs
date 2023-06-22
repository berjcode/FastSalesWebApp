using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.CreateBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.DeleteBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.RemoveBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.StateBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Commands.UpdateBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Queries.GetAllBankTransaction;
using QuickSalesApp.Application.Features.CompanyFeatures.BankTransactionFeatures.Queries.GetBankTransaction;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.BankTransaction;

public sealed class BankTransaction : ApiController
{
    public BankTransaction(IMediator mediator) : base(mediator)
    {
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateBankTransactionCommand request, CancellationToken cancellationToken)
    {
        CreateBankTransactionCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveBankTransactionCommand request, CancellationToken cancellationToken)
    {
        RemoveBankTransactionCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateBankTransactionCommand request, CancellationToken cancellationToken)
    {
        UpdateBankTransactionCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllBankTransactionQuery request)
    {

        PaginationResult<GetAllBankTransactionQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetBankTransactionQuery request, CancellationToken cancellationToken)
    {
        GetBankTransactionQueryResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> ChangeState(StateBankTransactionCommand request, CancellationToken cancellationToken)
    {
        StateBankTransactionCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);

    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(DeleteBankTransactionCommand request, CancellationToken cancellationToken)
    {
        DeleteBankTransactionResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }

}
