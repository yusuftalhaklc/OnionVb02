using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserProfileHandlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserProfileHandlers.Read;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserProfileQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserProfileCommands;

namespace OnionVb02.WebApi.Controllers.CQRS
{
    [Route("api/cqrs/[controller]")]
    [ApiController]
    public class AppUserProfileController : ControllerBase
    {
        private readonly GetAppUserProfileQueryHandler _getAppUserProfileQueryHandler;
        private readonly GetAppUserProfileByIdQueryHandler _getAppUserProfileByIdQueryHandler;
        private readonly CreateAppUserProfileCommandHandler _createAppUserProfileCommandHandler;
        private readonly DeleteAppUserProfileCommandHandler _deleteAppUserProfileCommandHandler;
        private readonly UpdateAppUserProfileCommandHandler _updateAppUserProfileCommandHandler;

        public AppUserProfileController(
            GetAppUserProfileQueryHandler getAppUserProfileQueryHandler,
            GetAppUserProfileByIdQueryHandler getAppUserProfileByIdQueryHandler,
            CreateAppUserProfileCommandHandler createAppUserProfileCommandHandler,
            DeleteAppUserProfileCommandHandler deleteAppUserProfileCommandHandler,
            UpdateAppUserProfileCommandHandler updateAppUserProfileCommandHandler)
        {
            _getAppUserProfileQueryHandler = getAppUserProfileQueryHandler;
            _getAppUserProfileByIdQueryHandler = getAppUserProfileByIdQueryHandler;
            _createAppUserProfileCommandHandler = createAppUserProfileCommandHandler;
            _deleteAppUserProfileCommandHandler = deleteAppUserProfileCommandHandler;
            _updateAppUserProfileCommandHandler = updateAppUserProfileCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserProfileList()
        {
            var values = await _getAppUserProfileQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserProfileById([FromRoute] int id)
        {
            var value = await _getAppUserProfileByIdQueryHandler.Handle(new GetAppUserProfileByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppUserProfileCommand command)
        {
            await _createAppUserProfileCommandHandler.Handle(command);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppUserProfileCommand command)
        {
            await _updateAppUserProfileCommandHandler.Handle(command);
            return Ok("Veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _deleteAppUserProfileCommandHandler.Handle(new DeleteAppUserProfileCommand(id));
            return Ok("Veri silindi");
        }
    }
}

