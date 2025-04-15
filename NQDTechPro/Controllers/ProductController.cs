using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NQDTechPro.Data;
using NQDTechPro.DTOs.Product;
using NQDTechPro.Interfaces;

namespace NQDTechPro.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly dbContext _dbContext;
        private readonly IProductServices _productServices;
        public ProductController(dbContext dbcontext, IProductServices productServices)
        {
            _dbContext = dbcontext;
            _productServices = productServices;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllProduct()
        {
            var result = await _productServices.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("by-catid")]
        public async Task<IActionResult> GetProductsByCategoryId(int catid)
        {
            var result = await _productServices.GetByCategoryIdAsync(catid);
            return Ok(result);
        }

        [HttpGet]
        [Route("by-brandid")]
        public async Task<IActionResult> GetProductsByBrandId(int brandid)
        {
            var result = await _productServices.GetByBrandIdAsync(brandid);
            return Ok(result);
        }

        [HttpGet]
        [Route("detail")]
        public async Task<IActionResult> GetProductDetail(int proid)
        {
            var result = await _productServices.GetByIdAsync(proid);
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProduct pro)
        {
            var result = await _productServices.CreateProductAsync(pro);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteProductAsync(int proid)
        {
            var result = await _productServices.DeleteProductAsync(proid);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductDto pro)
        {
            var result = await _productServices.UpdateProductAsync(pro);
            return Ok(result);
        }
    }
}
