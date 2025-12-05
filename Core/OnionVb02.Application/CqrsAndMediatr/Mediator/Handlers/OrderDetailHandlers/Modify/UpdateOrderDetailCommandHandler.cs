using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.OrderDetailCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderDetailHandlers.Modify
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand>
    {
        private readonly IOrderDetailRepository _repository;

        public UpdateOrderDetailCommandHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = await _repository.GetByIdAsync(request.Id);

            if (orderDetail == null)
                throw new Exception("OrderDetail not found");

            orderDetail.OrderId = request.OrderId;
            orderDetail.ProductId = request.ProductId;
            orderDetail.Status = Domain.Enums.DataStatus.Updated;
            orderDetail.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
        }
    }
}

