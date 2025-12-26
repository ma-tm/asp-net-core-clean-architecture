using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Orion.API.Controllers.SeedWork
{
    [ApiController]
    [Route("[controller]")]
    public class OrionBaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    }
}
