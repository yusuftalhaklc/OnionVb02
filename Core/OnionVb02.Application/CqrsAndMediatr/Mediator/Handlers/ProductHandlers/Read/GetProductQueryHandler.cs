using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.ProductHandlers.Read
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
    {
        private readonly IProductRepository _repository;

        public GetProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            List<Product> values = await _repository.GetAllAsync();
            return values.Select(
                x => new GetProductQueryResult 
                { 
                    Id = x.Id,
                    ProductName = x.ProductName, 
                    UnitPrice = x.UnitPrice,
                    CategoryId = x.CategoryId
                }).ToList();
        }
    }
}

