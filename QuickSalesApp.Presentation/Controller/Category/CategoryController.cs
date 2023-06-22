using EntityFrameworkCorePagination.Nuget.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.CreateCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.DeleteCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.RemoveCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.StateCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Commands.UpdateCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllFilterCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllJustCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetAllProductByCategoryId;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetCategory;
using QuickSalesApp.Application.Features.CompanyFeatures.CategoryFeatures.Queries.GetWithUnactive;
using QuickSalesApp.Presentation.Abstraction;


namespace QuickSalesApp.Presentation.Controller.Category;


public sealed class CategoryController : ApiController
{
    public CategoryController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        CreateCategoryCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Remove(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        RemoveCategoryCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        UpdateCategoryCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> GetAll(GetAllCategoryQuery request)
    {

        PaginationResult<GetAllCategoryQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> GetWithUnactive(GetWithUnactiveQuery request)
    {

        PaginationResult<GetWithUnactiveResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> GetAllFilter(GetAllFilterCategoryQuery request)
    {

        PaginationResult<GetAllFilterCategoryQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllJustCategory(GetAllJustCategoryQuery request)
    {

       IList<GetAllJustCategoryQueryResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> GetAllProductByCategoryId(GetAllProductByCategoryIdQuery request)
    {

        IList<GetAllProductByCategoryIdResponse> response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Get(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        GetCategoryQueryResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("[action]")]

    public async Task<IActionResult> ChangeState(StateCategoryCommand request, CancellationToken cancellationToken)
    {
        StateCategoryCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);

    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RemoveSoft(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        DeleteCategoryCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpOptions]
    public IActionResult GetAuthOptions()
    {
        Response.Headers.Add("Allow", "POST,OPTIONS");
        return Ok();
    }


}
