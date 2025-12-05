using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserHandlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.AppUserHandlers.Read;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.AppUserQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.AppUserCommands;

namespace OnionVb02.WebApi.Controllers.CQRS
{
    [Route("api/cqrs/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly GetAppUserQueryHandler _getAppUserQueryHandler;
        private readonly GetAppUserByIdQueryHandler _getAppUserByIdQueryHandler;
        private readonly CreateAppUserCommandHandler _createAppUserCommandHandler;
        private readonly DeleteAppUserCommandHandler _deleteAppUserCommandHandler;
        private readonly UpdateAppUserCommandHandler _updateAppUserCommandHandler;

        public AppUserController(
            GetAppUserQueryHandler getAppUserQueryHandler,
            GetAppUserByIdQueryHandler getAppUserByIdQueryHandler,
            CreateAppUserCommandHandler createAppUserCommandHandler,
            DeleteAppUserCommandHandler deleteAppUserCommandHandler,
            UpdateAppUserCommandHandler updateAppUserCommandHandler)
        {
            _getAppUserQueryHandler = getAppUserQueryHandler;
            _getAppUserByIdQueryHandler = getAppUserByIdQueryHandler;
            _createAppUserCommandHandler = createAppUserCommandHandler;
            _deleteAppUserCommandHandler = deleteAppUserCommandHandler;
            _updateAppUserCommandHandler = updateAppUserCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AppUserList()
        {
            var values = await _getAppUserQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserById([FromRoute] int id)
        {
            var value = await _getAppUserByIdQueryHandler.Handle(new GetAppUserByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAppUserCommand command)
        {
            await _createAppUserCommandHandler.Handle(command);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAppUserCommand command)
        {
            await _updateAppUserCommandHandler.Handle(command);
            return Ok("Veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _deleteAppUserCommandHandler.Handle(new DeleteAppUserCommand(id));
            return Ok("Veri silindi");
        }
    }
}

