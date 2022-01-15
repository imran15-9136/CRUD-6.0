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
        private const string ItemPath = @"Items";

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
        public async Task<IActionResult> GetAllAsync()
        {
            var data = await _itemManager.GetAllAsync();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet("GetAllItems")]
        public IActionResult GetAll()
        {
            var data = _itemManager.GetAll();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] ItemCreateDto model)
        {
            var item = await _itemManager.GetByIdAsync(id);
            if (item!=null)
            {
                if (ModelState.IsValid)
                {
                    if (model.Image != null)
                    {
                        if (item.ImagePath != null)
                        {
                            string previousImage = Path.Combine(_hostEnvironment.WebRootPath, ItemPath, item.ImagePath);
                            ImageProcess.ProcessDeleteImages(previousImage);
                        }
                        string imagePath = Path.Combine(_hostEnvironment.WebRootPath, ItemPath);
                        model.ImagePath = await ImageProcess.ProcessUploadImages(model.Image, imagePath);

                        var data = _mapper.Map(model, item);
                        var result = await _itemManager.UpdateAsync(data);

                        if(result.Succeeded)
                        {
                            return Ok(result);
                        }
                        return BadRequest();
                    }
                }
            }
            return NotFound();  
        }
    }
}
