﻿using AutoMapper;
using CRUD.BLL.Abstraction.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entity;
using Models.Request;

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ItemCategoryCreateDto category)
        {
            var data = await _categoryManager.GetByIdAsync(id);
            if (data!=null)
            {
                var value = _mapper.Map<ItemCategory>(category);
                var result = await _categoryManager.UpdateAsync(value);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return NotFound();
        }

        [HttpDelete]
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
