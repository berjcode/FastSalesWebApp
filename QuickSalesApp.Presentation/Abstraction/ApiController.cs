using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSalesApp.Presentation.Abstraction
{
    [ApiVersion("1.0", Deprecated =false)]
    [ApiController]
    [Route("api/{v:apiversion}/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected ApiController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
