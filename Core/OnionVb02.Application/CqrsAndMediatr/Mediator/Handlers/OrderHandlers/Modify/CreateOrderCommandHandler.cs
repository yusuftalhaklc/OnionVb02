using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderHandlers.Modify
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public CreateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                ShippingAddress = request.ShippingAddress,
                AppUserId = request.AppUserId,
                Status = Domain.Enums.DataStatus.Inserted,
                CreatedDate = DateTime.Now
            };

            await _repository.CreateAsync(order);
        }
    }
}

