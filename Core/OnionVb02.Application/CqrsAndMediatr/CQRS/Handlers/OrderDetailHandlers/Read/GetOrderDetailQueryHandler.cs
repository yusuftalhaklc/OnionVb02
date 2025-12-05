using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderDetailHandlers.Read
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public GetOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        // Todo: Mapper profiles için ödev
        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            List<OrderDetail> orderDetail = await _orderDetailRepository.GetAllAsync();

            return orderDetail.Select(od => new GetOrderDetailQueryResult
            {
                Id = od.Id,
                OrderId = od.OrderId,
                ProductId = od.ProductId
            }).ToList();
        }
    }
}

