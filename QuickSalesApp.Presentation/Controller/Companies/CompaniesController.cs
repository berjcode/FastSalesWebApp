using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuickSalesApp.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using QuickSalesApp.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase;
using QuickSalesApp.Application.Features.AppFeatures.CompanyFeatures.Queries.GetAllCompany;
using QuickSalesApp.Presentation.Abstraction;

namespace QuickSalesApp.Presentation.Controller.Companies
{
    public class CompaniesController : ApiController
    {
        public CompaniesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]

        public async Task<IActionResult> Create(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            CreateCompanyCommandResponse response = await _mediator.Send(request, cancellationToken);
            return Ok(response);

        }



        [HttpGet("[action]")]

        public async Task<IActionResult> MigrateCompanyDatabase()
        {
            MigrateCompanyDatabaseCommand request = new();
            MigrateCompanyDatabaseCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpGet("[action]")]

        public async Task<IActionResult> GetAll()
        {
            GetAllCompanyQuery request = new();
            GetAllCompanyQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }


        [HttpOptions]
        public IActionResult GetAuthOptions()
        {
            Response.Headers.Add("Allow", "POST;GET,OPTIONS");
            return Ok();
        }



    }
}
