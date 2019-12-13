using System.Threading.Tasks;
using API.Application.Followers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     [Authorize]
    public class FollowersController: ControllerBase
    {
        private readonly IMediator _mediator;
        public FollowersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{username}/follow")]
        public async Task<ActionResult<Unit>> Follow(string username){
            return await _mediator.Send(new Add.Command {UserName = username});
        }

        [HttpDelete("{username}/unfollow")]
        public async Task<ActionResult<Unit>> UnFollow(string username){
            return await _mediator.Send(new Delete.Command {UserName = username});
        }

    }
}