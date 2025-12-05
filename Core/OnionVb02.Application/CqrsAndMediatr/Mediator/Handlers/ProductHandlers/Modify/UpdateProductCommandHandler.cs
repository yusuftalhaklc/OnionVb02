using MediatR;
using OnionVb02.Application.CqrsAndMediatr.Mediator.Commands.ProductCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Handlers.ProductHandlers.Modify
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
                throw new Exception("Product not found");

            product.ProductName = request.ProductName;
            product.UnitPrice = request.UnitPrice;
            product.CategoryId = request.CategoryId;
            product.Status = Domain.Enums.DataStatus.Updated;
            product.UpdatedDate = DateTime.Now;

            await _repository.SaveChangesAsync();
        }
    }
}

