using System.Threading.Tasks;
using API.Application.User;
using API.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("reg")]
        public async Task<ActionResult<User>> Registration(Registration.Command cmd)
        {
            return await _mediator.Send(cmd);
        }
        
        [Authorize]
        [HttpGet("currentuser")]
        public async Task<ActionResult<User>> currentuser()
        {
            return await _mediator.Send(new CurrentUser.Query());
        }
    }
}