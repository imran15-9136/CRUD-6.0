using AutoMapper;
using CRUD.BLL.Abstraction.Items;
using CRUD.Configuration.Library;
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
        private readonly IWebHostEnvironment _hostEnvironment;
        private const string? ItemPath = @"Items";

        public ItemController(IItemManager itemManager, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            _itemManager = itemManager;
            _mapper = mapper;
            _hostEnvironment = hostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync([FromForm] ItemCreateDto model)
        {
            if (ModelState.IsValid)
            {
                if (model.Image != null)
                {
                    string imagePath = Path.Combine(_hostEnvironment.WebRootPath, ItemPath);
                    model.ImagePath = await ImageProcess.ProcessUploadImages(model.Image, imagePath);
                }
                var value = _mapper.Map<Item>(model);
                var data = await _itemManager.AddAsync(value);

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
