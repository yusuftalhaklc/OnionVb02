using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.ProductHandlers.Modify
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                CategoryId = request.CategoryId,
                Status = Domain.Enums.DataStatus.Inserted,
                CreatedDate = DateTime.Now
            };

            await _repository.CreateAsync(product);
        }
    }
}

