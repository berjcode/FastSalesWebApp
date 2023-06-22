using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.CreateBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.DeleteBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.RemoveBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.StateBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Commands.UpdateBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetAllBankAccount;
using QuickSalesApp.Application.Features.CompanyFeatures.BankAccountFeatures.Queries.GetBankAccount;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.BankAccount;

public sealed class BankAccount : ApiController
{
    public BankAccount(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateBankAccountCommand request, CancellationToken cancellationToken)
    {
        CreateBankAccountCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveBankAccountCommand request, CancellationToken cancellationToken)
    {
        RemoveBankAccountCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdateBankAccountCommand request, CancellationToken cancellationToken)
    {
        UpdateBankAccountCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllBankAccountQuery request)
    {

        PaginationResult<GetAllBankAccountQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetBankAccountQuery request, CancellationToken cancellationToken)
    {
        GetBankAccountQueryResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> ChangeState(StateBankAccountCommand request, CancellationToken cancellationToken)
    {
        StateBankAccountCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(DeleteBankAccountCommand request, CancellationToken cancellationToken)
    {
        DeleteBankAccountCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

   [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }



}
