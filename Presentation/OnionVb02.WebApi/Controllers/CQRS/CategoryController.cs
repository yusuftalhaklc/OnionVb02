using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.CategoryHandlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.CategoryHandlers.Read;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;

namespace OnionVb02.WebApi.Controllers.CQRS
{
    [Route("api/cqrs/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly DeleteCategoryCommandHandler _deleteCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;

        public CategoryController(
            GetCategoryQueryHandler getCategoryQueryHandler,
            GetCategoryByIdQueryHandler getCategoryByIdQueryHandler,
            CreateCategoryCommandHandler createCategoryCommandHandler,
            DeleteCategoryCommandHandler deleteCategoryCommandHandler,
            UpdateCategoryCommandHandler updateCategoryCommandHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _deleteCategoryCommandHandler = deleteCategoryCommandHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
            var value = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            await _createCategoryCommandHandler.Handle(command);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("Veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _deleteCategoryCommandHandler.Handle(new DeleteCategoryCommand(id));
            return Ok("Veri silindi");
        }
    }
}

