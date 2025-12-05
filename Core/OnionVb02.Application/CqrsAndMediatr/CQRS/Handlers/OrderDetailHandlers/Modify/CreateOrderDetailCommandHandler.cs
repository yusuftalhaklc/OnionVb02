using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderDetailCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderDetailHandlers.Modify
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IOrderDetailRepository _repository;
        private readonly IMapper _mapper;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            var orderDetail = _mapper.Map<OrderDetail>(command);
            orderDetail.Status = Domain.Enums.DataStatus.Inserted;
            orderDetail.CreatedDate = DateTime.Now;
            
            await _repository.CreateAsync(orderDetail);
        }
    }
}

