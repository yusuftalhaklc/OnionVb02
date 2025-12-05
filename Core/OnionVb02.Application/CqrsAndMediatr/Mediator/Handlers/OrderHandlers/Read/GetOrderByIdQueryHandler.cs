using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderHandlers.Read
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>
    {
        private readonly IOrderRepository _repository;

        public GetOrderByIdQueryHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            Order order = await _repository.GetByIdAsync(request.Id);

            if (order == null)
                throw new Exception("Order not found");

            return new GetOrderByIdQueryResult
            {
                Id = order.Id,
                ShippingAddress = order.ShippingAddress,
                AppUserId = order.AppUserId
            };
        }
    }
}

