using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderHandlers.Modify
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.Id);

            if (order == null)
                throw new Exception("Order not found");

            order.ShippingAddress = request.ShippingAddress;
            order.AppUserId = request.AppUserId;
            order.Status = Domain.Enums.DataStatus.Updated;
            order.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
        }
    }
}

