using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.OrderResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderHandlers.Read
{
    public class GetOrderQueryHandler
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        // Todo: Mapper profiles için ödev
        public async Task<List<GetOrderQueryResult>> Handle()
        {
            List<Order> order = await _orderRepository.GetAllAsync();

            return order.Select(o => new GetOrderQueryResult
            {
                Id = o.Id,
                ShippingAddress = o.ShippingAddress,
                AppUserId = o.AppUserId
            }).ToList();
        }
    }
}

