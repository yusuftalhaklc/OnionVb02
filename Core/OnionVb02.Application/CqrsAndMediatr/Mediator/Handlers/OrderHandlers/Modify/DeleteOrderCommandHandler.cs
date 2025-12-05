using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderHandlers.Modify
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _repository;

        public DeleteOrderCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            Order value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}

