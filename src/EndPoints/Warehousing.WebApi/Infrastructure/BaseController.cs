using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Warehousing.WebApi.Infrastructure
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator Mediator { get; }

        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
