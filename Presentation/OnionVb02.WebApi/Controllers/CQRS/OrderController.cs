using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderHandlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderHandlers.Read;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.OrderQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands;

namespace OnionVb02.WebApi.Controllers.CQRS
{
    [Route("api/cqrs/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly GetOrderQueryHandler _getOrderQueryHandler;
        private readonly GetOrderByIdQueryHandler _getOrderByIdQueryHandler;
        private readonly CreateOrderCommandHandler _createOrderCommandHandler;
        private readonly DeleteOrderCommandHandler _deleteOrderCommandHandler;
        private readonly UpdateOrderCommandHandler _updateOrderCommandHandler;

        public OrderController(
            GetOrderQueryHandler getOrderQueryHandler,
            GetOrderByIdQueryHandler getOrderByIdQueryHandler,
            CreateOrderCommandHandler createOrderCommandHandler,
            DeleteOrderCommandHandler deleteOrderCommandHandler,
            UpdateOrderCommandHandler updateOrderCommandHandler)
        {
            _getOrderQueryHandler = getOrderQueryHandler;
            _getOrderByIdQueryHandler = getOrderByIdQueryHandler;
            _createOrderCommandHandler = createOrderCommandHandler;
            _deleteOrderCommandHandler = deleteOrderCommandHandler;
            _updateOrderCommandHandler = updateOrderCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var values = await _getOrderQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var value = await _getOrderByIdQueryHandler.Handle(new GetOrderByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            await _createOrderCommandHandler.Handle(command);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderCommand command)
        {
            await _updateOrderCommandHandler.Handle(command);
            return Ok("Veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _deleteOrderCommandHandler.Handle(new DeleteOrderCommand(id));
            return Ok("Veri silindi");
        }
    }
}

