using AutoMapper;
using EFCoreAssignment02.Infrastructure.Interfaces;
using EFCoreAssignment02.Infrastructure.ModelDto;
using EFCoreAssignment02.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment02.WebApp.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employees>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<Employees>>> GetAllEmployees()
        {
            var employeesList = await _employeeService.GetAll();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(employeesList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employees>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            if (!(await _employeeService.IsExist(id)))
            {
                return NotFound();
            }

            var employee = _mapper.Map<EmployeeResponse>(await _employeeService.GetById(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employees>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Task<Employees>>> AddEmployee([FromBody] EmployeeRequest employeeRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var employee = await _employeeService.AddEmployee(employeeRequest);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteEmployee(Guid id)
        {
            if (!(await _employeeService.IsExist(id)))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _employeeService.DeleteEmployee(id);
            return Ok("Successfully Deleted");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Task<Employees>>> UpdateEmployee(Guid id, [FromBody] EmployeeRequest employee)
        {
            if (!(await _employeeService.IsExist(id)))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updateEmployee = await _employeeService.UpdateEmployee(id, employee);
            return Ok(updateEmployee);
        }

        [HttpGet("with-department")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<string>>> GetWithDepartment()
        {
             return await _employeeService.GetAllWithDepartment();
        }

        [HttpGet("with-project")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<string>>> GetWithProject()
        {
            return await _employeeService.GetAllWithProject();
        }
        [HttpGet("with-salary-and-joineddate")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<string>>> GetWithSalary()
        {
            return await _employeeService.GetWithSalaryAndJoinDated();
        }
    }
}

