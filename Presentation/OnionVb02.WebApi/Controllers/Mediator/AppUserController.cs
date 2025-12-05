using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserQueries;

namespace OnionVb02.WebApi.Controllers.Mediator
{
    [Route("api/mediator/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserList()
        {
            var result = await _mediator.Send(new GetAppUserQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetAppUserByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("Veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteAppUserCommand { Id = id });
            return Ok("Veri silindi");
        }
    }
}

