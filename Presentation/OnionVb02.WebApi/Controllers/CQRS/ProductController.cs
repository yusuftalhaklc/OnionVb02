using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.ProductHandlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.ProductHandlers.Read;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;

namespace OnionVb02.WebApi.Controllers.CQRS
{
    [Route("api/cqrs/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly DeleteProductCommandHandler _deleteProductCommandHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;

        public ProductController(
            GetProductQueryHandler getProductQueryHandler,
            GetProductByIdQueryHandler getProductByIdQueryHandler,
            CreateProductCommandHandler createProductCommandHandler,
            DeleteProductCommandHandler deleteProductCommandHandler,
            UpdateProductCommandHandler updateProductCommandHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _getProductQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var value = await _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            await _createProductCommandHandler.Handle(command);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommand command)
        {
            await _updateProductCommandHandler.Handle(command);
            return Ok("Veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _deleteProductCommandHandler.Handle(new DeleteProductCommand(id));
            return Ok("Veri silindi");
        }
    }
}

