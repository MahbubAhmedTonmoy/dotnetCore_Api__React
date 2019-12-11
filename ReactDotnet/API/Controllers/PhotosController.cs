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

    }
}