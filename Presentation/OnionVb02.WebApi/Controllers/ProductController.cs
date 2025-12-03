using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnionVb02.Application.DTOClasses;
using OnionVb02.Application.ManagerInterfaces;
using OnionVb02.WebApi.RequestModels.Products;
using OnionVb02.WebApi.ResponseModels.Products;

namespace OnionVb02.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;

        public ProductController(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            List<ProductDto> values = await _productManager.GetAllAsync();
            return Ok(_mapper.Map<List<ProductResponseModel>>(values));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            ProductDto value = await _productManager.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequestModel model)
        {
            ProductDto product = _mapper.Map<ProductDto>(model);
            await _productManager.CreateAsync(product);
            return Ok("Veri eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequestModel model)
        {
            ProductDto product = _mapper.Map<ProductDto>(model);
            await _productManager.UpdateAsync(product);
            return Ok("Veri güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteProduct(int id)
        {
            string result = await _productManager.SoftDeleteAsync(id);
            return Ok(result);
        }

        [HttpDelete("hard/{id}")]
        public async Task<IActionResult> HardDeleteProduct(int id)
        {
            string result = await _productManager.HardDeleteAsync(id);
            return Ok(result);
        }
    }
}

