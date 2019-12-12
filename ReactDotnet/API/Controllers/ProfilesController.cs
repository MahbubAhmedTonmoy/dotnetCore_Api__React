using System.Threading.Tasks;
using API.Application.Profiles;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    
    [Route("api/[controller]")]

    [Authorize]
    public class ProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfilesController(IMediator mediator)
        {
            _mediator = mediator;   
        }  

        [HttpGet("details/{username}")]
        public async Task<ActionResult<Profile>> DetailsProfile(string username)
        {
            return await _mediator.Send(new Details.Query{Username = username});
        }
    }
}