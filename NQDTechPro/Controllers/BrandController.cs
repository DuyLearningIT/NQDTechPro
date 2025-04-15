using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NQDTechPro.Data;
using NQDTechPro.DTOs.Brand;
using NQDTechPro.Interfaces;

namespace NQDTechPro.Controllers
{
    [Route("api/brand")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly dbContext _dbcontext;
        private readonly IBrandServices _brandService;
        public BrandController(dbContext dbcontext, IBrandServices brandServices)
        {
            _dbcontext = dbcontext;
            _brandService = brandServices;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _brandService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("by-brandId")]
        public async Task<IActionResult> GetById(int brandid) {
            var result = await _brandService.GetByIdAsync(brandid);
            return Ok(result);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatebrandAsync(CreateBrand brand)
        {
            var result = await _brandService.CreateBrandAsync(brand);
            return Ok(result);
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateBrandAsync(BrandDto brand)
        {
            var result = await _brandService.UpdateBrand(brand);
            return Ok(result);
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteBrandAsync(int brandId)
        {
            var result = await _brandService.DeleteBrandAsync(brandId);
            return Ok(result);
        }
    }
}
