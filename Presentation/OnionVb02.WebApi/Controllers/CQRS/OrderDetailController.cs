using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderDetailHandlers.Modify;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderDetailHandlers.Read;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.OrderDetailQueries;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;

namespace OnionVb02.WebApi.Controllers.CQRS
{
    [Route("api/cqrs/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly DeleteOrderDetailCommandHandler _deleteOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;

        public OrderDetailController(
            GetOrderDetailQueryHandler getOrderDetailQueryHandler,
            GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler,
            CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
            DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler,
            UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _deleteOrderDetailCommandHandler = deleteOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById([FromRoute] int id)
        {
            var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("Veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _deleteOrderDetailCommandHandler.Handle(new DeleteOrderDetailCommand(id));
            return Ok("Veri silindi");
        }
    }
}

