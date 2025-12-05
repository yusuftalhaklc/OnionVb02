using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Commands.ProductCommands;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.ProductHandlers.Modify
{
    public class CreateProductCommandHandler
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateProductCommand command)
        {
            var product = _mapper.Map<Product>(command);
            product.Status = Domain.Enums.DataStatus.Inserted;
            product.CreatedDate = DateTime.Now;
            
            await _repository.CreateAsync(product);
        }
    }
}

