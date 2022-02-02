using AutoMapper;
using CRUD.BLL.Abstraction.Category;
using CRUD.Configuration.Library;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entity;
using Models.Request;
using Models.Responses;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryManager categoryManager, IMapper mapper)
        {
            _categoryManager = categoryManager;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync([FromBody] ItemCategory category)
        {
            if (ModelState.IsValid)
            {
                var data = await _categoryManager.AddAsync(category);
                if (data.Succeeded)
                {
                    var encrypt = EncryptProcess.EncryptString(category.Name);
                    var dcrypt = EncryptProcess.DecryptString(encrypt);
                    return Ok(data);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryAsync()
        {
            try
            {
                var data = await _categoryManager.GetAllAsync();
                if (data != null)
                {
                    var category = _mapper.Map<ICollection<ItemCategoryReturnDto>>(data);
                    return Ok(category);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ItemCategoryCreateDto category)
        {
            var data = await _categoryManager.GetByIdAsync(id);
            if (data != null)
            {
                var value = _mapper.Map(category, data);
                var result = await _categoryManager.UpdateAsync(value);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            if (id > 0)
            {
                var result = await _categoryManager.RemoveAsync(id);
                if (result.Succeeded)
                {
                    return Ok();
                }
                return BadRequest();
            }
            return NotFound();
        }
    }
}
