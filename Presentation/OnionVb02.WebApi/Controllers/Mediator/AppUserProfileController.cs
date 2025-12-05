using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.AppUserProfileCommands;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.AppUserProfileQueries;

namespace OnionVb02.WebApi.Controllers.Mediator
{
    [Route("api/mediator/[controller]")]
    [ApiController]
    public class AppUserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserProfileList()
        {
            var result = await _mediator.Send(new GetAppUserProfileQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserProfileById([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetAppUserProfileByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppUserProfileCommand command)
        {
            await _mediator.Send(command);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppUserProfileCommand command)
        {
            await _mediator.Send(command);
            return Ok("Veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteAppUserProfileCommand { Id = id });
            return Ok("Veri silindi");
        }
    }
}

