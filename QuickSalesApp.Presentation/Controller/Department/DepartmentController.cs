using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.CreateDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.DeleteDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.RemoveDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.StateDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Commands.UpdateDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetAllDepartment;
using QuickSalesApp.Application.Features.CompanyFeatures.DepartmentFeatures.Query.GetDepartment;
using QuickSalesApp.Presentation.Abstraction;

namespace QuickSalesApp.Presentation.Controller.Department;

public sealed class DepartmentController : ApiController
{
    public DepartmentController(IMediator mediator) : base(mediator)
    {
    }


    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        CreateDepartmentCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveDepartmentCommand request, CancellationToken cancellationToken)
    {
        RemoveDepartmentCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> Update(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        UpdateDepartmentCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> GetAll(GetAllDepartmentQuery request, CancellationToken cancellationToken)
    {

        PaginationResult<GetAllDepartmentQueryResponse> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetDepartmentQuery request, CancellationToken cancellationToken)
    {
        GetDepartmentQueryResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> ChangeState(StateDepartmentCommand request, CancellationToken cancellationToken)
    {
        StateDepartmentCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);

    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        DeleteCustomerCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }

}
