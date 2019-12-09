using System.Threading.Tasks;
using API.Application.User;
using API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
     [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("login")]
        public async Task<ActionResult<User>> Login(Login.Query query)
        {
            return await _mediator.Send(query);
        }
    }
}