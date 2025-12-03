using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.DTOClasses;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.Application.RequestModels.OrderDetails;
using OnionVb02.WebApi.ResponseModels.OrderDetails;

namespace OnionVb02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailManager _orderDetailManager;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailManager orderDetailManager, IMapper mapper)
        {
            _orderDetailManager = orderDetailManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            List<OrderDetailDto> values = await _orderDetailManager.GetAllAsync();
            return Ok(_mapper.Map<List<OrderDetailResponseModel>>(values));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            OrderDetailDto value = await _orderDetailManager.GetByIdAsync(id);
            return Ok(_mapper.Map<OrderDetailResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailRequestModel model)
        {
            OrderDetailDto orderDetail = _mapper.Map<OrderDetailDto>(model);
            await _orderDetailManager.CreateAsync(orderDetail);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailRequestModel model)
        {
            OrderDetailDto orderDetail = _mapper.Map<OrderDetailDto>(model);
            await _orderDetailManager.UpdateAsync(orderDetail);
            return Ok("Veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteOrderDetail(int id)
        {
            string result = await _orderDetailManager.SoftDeleteAsync(id);
            return Ok(result);
        }

        [HttpDelete("hard/{id}")]
        public async Task<IActionResult> HardDeleteOrderDetail(int id)
        {
            string result = await _orderDetailManager.HardDeleteAsync(id);
            return Ok(result);
        }
    }
}

