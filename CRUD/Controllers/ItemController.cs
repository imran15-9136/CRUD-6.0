using AutoMapper;
using CRUD.BLL.Abstraction.Items;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entity;
using Models.Request;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemManager _itemManager;
        private readonly IMapper _mapper;

        public ItemController(IItemManager itemManager, IMapper mapper)
        {
            _itemManager = itemManager;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync([FromBody] Item model)
        {
            if (ModelState.IsValid)
            {
                //var value = _mapper.Map<Item>(model);
                var data = await _itemManager.AddAsync(model);
                if (data.Succeeded)
                {
                    return Ok(data);
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            if (id>0)
            {
                var data = await _itemManager.GetByIdAsync(id);
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest(string.Empty);
        }
    }
}
