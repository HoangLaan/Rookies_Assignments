using EFCoreAssignment02.WebApp.Database;
using EFCoreAssignment02.WebApp.Interfaces;
using EFCoreAssignment02.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using EFCoreAssignment02.Infrastructure.Interfaces;
using AutoMapper;
using EFCoreAssignment02.Infrastructure.ModelDto;
using NuGet.Protocol;

namespace EFCoreAssignment02.WebApp.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Departments>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<Departments>>> GetAllDepartMents()
        {
            var departmentsList = await _departmentService.GetAll();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(departmentsList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Departments>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetDepartmentById(Guid id)
        {
            if (! (await _departmentService.IsExist(id)))
            {
                return NotFound();
            }

            var department = _mapper.Map<DepartmentResponse>(await _departmentService.GetById(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(department);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Departments>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Task<Departments>>> AddDepartment([FromBody] DepartmentsRequest departments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _departmentService.AddDepartment(departments);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteDepartment(Guid id)
        {
            if (!(await _departmentService.IsExist(id)))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _departmentService.DeleteDepartment(id);
            return Ok("Successfully Deleted");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Task<Departments>>> UpdateDepartment(Guid id, [FromBody] DepartmentsRequest department)
        {
            if (!(await _departmentService.IsExist(id)))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updateDepartment = await _departmentService.UpdateDepartment(id, department);
            return Ok(updateDepartment);

        }
    }
}
