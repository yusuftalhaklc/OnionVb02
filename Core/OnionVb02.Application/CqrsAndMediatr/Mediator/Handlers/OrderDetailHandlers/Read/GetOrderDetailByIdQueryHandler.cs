using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderDetailHandlers.Read
{
    public class GetOrderDetailByIdQueryHandler : IRequestHandler<GetOrderDetailByIdQuery, GetOrderDetailByIdQueryResult>
    {
        private readonly IOrderDetailRepository _repository;

        public GetOrderDetailByIdQueryHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery request, CancellationToken cancellationToken)
        {
            OrderDetail orderDetail = await _repository.GetByIdAsync(request.Id);

            if (orderDetail == null)
                throw new Exception("OrderDetail not found");

            return new GetOrderDetailByIdQueryResult
            {
                Id = orderDetail.Id,
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId
            };
        }
    }
}

