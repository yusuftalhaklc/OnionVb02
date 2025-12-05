using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.OrderDetailQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.OrderDetailResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.OrderDetailHandlers.Read
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, List<GetOrderDetailQueryResult>>
    {
        private readonly IOrderDetailRepository _repository;

        public GetOrderDetailQueryHandler(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            List<OrderDetail> values = await _repository.GetAllAsync();
            return values.Select(
                x => new GetOrderDetailQueryResult 
                { 
                    Id = x.Id,
                    OrderId = x.OrderId, 
                    ProductId = x.ProductId
                }).ToList();
        }
    }
}

