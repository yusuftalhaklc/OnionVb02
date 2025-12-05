using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderDetailHandlers.Modify
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand>
    {
        private readonly IOrderDetailRepository _repository;

        public DeleteOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
        {
            OrderDetail value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}

