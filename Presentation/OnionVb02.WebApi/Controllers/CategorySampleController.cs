using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.Read;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.CategoryResults;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.CategoryQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.CategoryCommands;

namespace OnionVb02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorySampleController : ControllerBase
    {
        private readonly GetCategoryQueryHandler getCategoryQueryHandler;
        private readonly GetCategoryByIdQueryHandler getCategoryByIdQueryHandler;

        private readonly CreateCategoryCommandHandler createCategoryCommandHandler;
        private readonly DeleteCategoryCommandHandler deleteCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler updateCategoryCommandHandler;

        public CategorySampleController(GetCategoryQueryHandler getCategoryQueryHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, CreateCategoryCommandHandler createCategoryCommandHandler, DeleteCategoryCommandHandler deleteCategoryCommandHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler)
        {
            this.getCategoryQueryHandler = getCategoryQueryHandler;
            this.getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            this.createCategoryCommandHandler = createCategoryCommandHandler;
            this.deleteCategoryCommandHandler = deleteCategoryCommandHandler;
            this.updateCategoryCommandHandler = updateCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList() {
            List<GetCategoryQueryResult> values = await getCategoryQueryHandler.Handle();
            return Ok(values);
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {
           GetCategoryByIdQueryResult value = await getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
           return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            await createCategoryCommandHandler.Handle(command);
            return Ok("veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
            await updateCategoryCommandHandler.Handle(command);
            return Ok("güncellendi");
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoryCommand command)
        {
            await deleteCategoryCommandHandler.Handle(command);
            return Ok("silindi");
        }
    }
}
