using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderDetailHandlers.Read
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            List<OrderDetail> orderDetail = await _orderDetailRepository.GetAllAsync();
            return _mapper.Map<List<GetOrderDetailQueryResult>>(orderDetail);
        }
    }
}

