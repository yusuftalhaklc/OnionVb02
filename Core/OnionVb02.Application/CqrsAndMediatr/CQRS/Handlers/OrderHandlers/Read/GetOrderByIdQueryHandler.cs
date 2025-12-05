using OnionVb02.Application.CqrsAndMediatr.CQRS.Queries.OrderQueries;
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
    public class GetOrderByIdQueryHandler
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery query)
        {
            Order order = await _orderRepository.GetByIdAsync(query.Id);

            return new GetOrderByIdQueryResult
            {
                Id = order.Id,
                ShippingAddress = order.ShippingAddress,
                AppUserId = order.AppUserId
            };
        }
    }
}

