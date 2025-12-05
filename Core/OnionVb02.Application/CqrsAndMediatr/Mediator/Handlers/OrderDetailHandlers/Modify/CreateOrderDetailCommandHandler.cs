using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderDetailHandlers.Modify
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand>
    {
        private readonly IOrderDetailRepository _repository;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = new OrderDetail
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Status = Domain.Enums.DataStatus.Inserted,
                CreatedDate = DateTime.Now
            };

            await _repository.CreateAsync(orderDetail);
        }
    }
}

