using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.DTOClasses;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.WebApi.RequestModels.Orders;
using OnionVb02.WebApi.ResponseModels.Orders;

namespace OnionVb02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;

        public OrderController(IOrderManager orderManager, IMapper mapper)
        {
            _orderManager = orderManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            List<OrderDto> values = await _orderManager.GetAllAsync();
            return Ok(_mapper.Map<List<OrderResponseModel>>(values));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            OrderDto value = await _orderManager.GetByIdAsync(id);
            return Ok(_mapper.Map<OrderResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequestModel model)
        {
            OrderDto order = _mapper.Map<OrderDto>(model);
            await _orderManager.CreateAsync(order);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequestModel model)
        {
            OrderDto order = _mapper.Map<OrderDto>(model);
            await _orderManager.UpdateAsync(order);
            return Ok("Veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteOrder(int id)
        {
            string result = await _orderManager.SoftDeleteAsync(id);
            return Ok(result);
        }

        [HttpDelete("hard/{id}")]
        public async Task<IActionResult> HardDeleteOrder(int id)
        {
            string result = await _orderManager.HardDeleteAsync(id);
            return Ok(result);
        }
    }
}

