using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.CreatePersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.RemovePersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.RemoveSoftPersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.StatePersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Commands.UpdatePersonal;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetAll;
using QuickSalesApp.Application.Features.CompanyFeatures.PersonalFeatures.Queries.GetById;
using QuickSalesApp.Presentation.Abstraction;

namespace QuickSalesApp.Presentation.Controller.Personel;

public class PersonelController : ApiController
{
    public PersonelController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAll(GetAllPersonalQuery query)
    {
        PaginationResult<GetAllPersonalQueryResponse> response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreatePersonalCommand command)
    {
        CreatePersonalCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemovePersonalCommand command)
    {
        RemovePersonalCommandResponse response =  await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(RemoveSoftPersonalCommand command)
    {
        RemoveSoftPersonalCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> ChangeState(StatePersonalCommand command)
    {
        StatePersonalCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetByIdPersonalQuery command)
    {
        GetByIdPersonalQueryResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Update(UpdatePersonalCommand command)
    {
        UpdatePersonalCommandResponse response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }
}
