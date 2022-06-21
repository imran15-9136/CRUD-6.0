using AutoMapper;
using CRUD.BLL.Abstraction.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entity;
using Models.Request;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeGroupManager employeeGroupManager;
        private readonly IEmployeeManager employeeManager;
        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeManager employeeManager, IEmployeeGroupManager employeeGroupManager, IMapper _mapper)
        {
            this.employeeManager = employeeManager;
            this.employeeGroupManager = employeeGroupManager;
            this._mapper = _mapper;
        }

        [HttpPost("EmployeeGroup")]
        public async Task<IActionResult> AddEmployeeGroupAsync([FromBody] EmployeeGroupCreateDto model)
        {
            if (ModelState.IsValid)
            {
                //category.Id = System.Guid.NewGuid();
                var group = _mapper.Map<EmployeeGroup>(model);
                var data = await employeeGroupManager.AddAsync(group);
                if (data.Succeeded)
                {
                    return Ok(data);
                }
            }
            return BadRequest();
        }

        [HttpPost("Employee")]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeCreateDto model)
        {
            if (ModelState.IsValid)
            {
                var employee = _mapper.Map<Employees>(model);
                //employee.Id = System.Guid.NewGuid();
                //employee.EmployeeGroupId = Guid.Parse(model.EmployeeGroupId);
                var data = await employeeManager.AddAsync(employee);
                if (data.Succeeded)
                {
                    return Ok(data);
                }
            }
            return BadRequest();
        }

        [HttpGet("EmployeeGroup")]
        public async Task<IActionResult> GetEmployeeGroupAsync()
        {
            try
            {
                var data = await employeeGroupManager.GetAllAsync();
                if (data != null)
                {
                    
                    return Ok(data);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
