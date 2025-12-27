using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Orion.API.Controllers.SeedWork;
using Orion.Application.AccountAppLayer.UseCases.UserUseCases.GetUserById;

namespace Orion.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : OrionBaseController
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            var request = new GetUserByIdRequest { Id = id };
            var response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
