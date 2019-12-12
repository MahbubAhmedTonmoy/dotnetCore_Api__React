using System.Threading.Tasks;
using API.Application.Photos;
using API.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
     [Route("api/[controller]")]
     [ApiController]
     [Authorize]
    public class PhotosController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PhotosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Photo>> Add([FromForm]Add.Command cmd){
            return await _mediator.Send(cmd);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Unit>> Delete(string id)
        {
            return await _mediator.Send(new Delete.Command{Id = id});
        }

        [HttpPost("set/{id}")]
        public async Task<ActionResult<Unit>> SetMain(string id)
        {
            return await _mediator.Send(new SetMain.Command {Id = id});
        }
    }
}