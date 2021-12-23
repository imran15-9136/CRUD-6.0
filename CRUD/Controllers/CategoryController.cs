using CRUD.BLL.Abstraction.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entity;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync([FromBody] ItemCategory category)
        {
            if (ModelState.IsValid)
            {
                var data = await _categoryManager.AddAsync(category);
                if (data.Succeeded)
                {
                    return Ok(data);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryAsync()
        {
            var data = await _categoryManager.GetAllAsync();
            if (data!= null)
            {
                return Ok(data);
            }
            return NotFound();

        }
    }
}
