using OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ProductResults;
using OnionVb02.Contract.RepositoryInterfaces;
using OnionVb02.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Handlers.ProductHandlers.Read
{
    public class GetProductQueryHandler
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // Todo: Mapper profiles için ödev
        public async Task<List<GetProductQueryResult>> Handle()
        {
            List<Product> product = await _productRepository.GetAllAsync();

            return product.Select(p => new GetProductQueryResult
            {
                Id = p.Id,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                CategoryId = p.CategoryId
            }).ToList();
        }
    }
}

