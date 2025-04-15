using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NQDTechPro.Data;
using NQDTechPro.DTOs.Category;
using NQDTechPro.Interfaces;

namespace NQDTechPro.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly dbContext _dbContext;
        private readonly ICategoryServices _categoryService;

        public CategoryController(dbContext dbcontext, ICategoryServices categoryService)
        {
            _categoryService = categoryService;
            _dbContext = dbcontext;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _categoryService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("detail")]
        public async Task<IActionResult> GetCategoryByIdAsync(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategory cat)
        {
            var result = await _categoryService.CreateCategoryAsync(cat);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateCategoryAsync([FromBody] CategoryDto cat)
        {
            var result = await _categoryService.UpdateCategoryAsync(cat);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            return Ok(result);
        }
    }
}
