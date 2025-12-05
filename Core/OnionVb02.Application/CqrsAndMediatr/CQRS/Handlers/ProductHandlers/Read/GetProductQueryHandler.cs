using AutoMapper;
using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.ProductHandlers.Read
{
    public class GetProductQueryHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetProductQueryResult>> Handle()
        {
            List<Product> product = await _productRepository.GetAllAsync();
            return _mapper.Map<List<GetProductQueryResult>>(product);
        }
    }
}

