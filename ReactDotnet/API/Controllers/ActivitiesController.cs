using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Application.Activities;
using API.Domain;
using API.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     [Route("api/[controller]")]
     [ApiController]
     [Authorize]
    public class ActivitiesController: ControllerBase
    {
        private readonly IMediator _mediator;
        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("test")]
        public IActionResult test()
        {
            return Ok();
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<ActivityDTO>>> List()
        {
            return await _mediator.Send(new list.Query());
        }

        [HttpGet("list/{id}")]
        public async Task<ActionResult<ActivityDTO>> Details(Guid id)
        {
            return await _mediator.Send(new details.Query{Id = id});
        }

        [HttpPost("create")]
        public async Task<ActionResult<Unit>> Create(Create.Command command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, Edit.Command command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command{Id = id});
        }
    }
}