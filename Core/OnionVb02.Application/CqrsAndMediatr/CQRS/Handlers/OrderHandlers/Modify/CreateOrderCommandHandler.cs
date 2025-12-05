using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.OrderCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.OrderHandlers.Modify
{
    public class CreateOrderCommandHandler
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateOrderCommand command)
        {
            var order = _mapper.Map<Order>(command);
            order.Status = Domain.Enums.DataStatus.Inserted;
            order.CreatedDate = DateTime.Now;
            
            await _repository.CreateAsync(order);
        }
    }
}

