using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Queries.ProductQueries;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.ProductHandlers.Read
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            Product product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
                throw new Exception("Product not found");

            return new GetProductByIdQueryResult
            {
                Id = product.Id,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                CategoryId = product.CategoryId
            };
        }
    }
}

