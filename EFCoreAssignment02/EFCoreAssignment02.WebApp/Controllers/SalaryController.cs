using AutoMapper;
using EFCoreAssignment02.Infrastructure.Interfaces;
using EFCoreAssignment02.Infrastructure.ModelDto;
using EFCoreAssignment02.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment02.WebApp.Controllers
{
    [Route("api/salary")]
    [ApiController]
    public class SalaryController : ControllerBase
    { 
    private readonly ISalaryService _salaryService;

    public IMapper _mapper;

    public SalaryController(ISalaryService salaryService, IMapper mapper)
    {
            _salaryService = salaryService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Salaries>))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<List<Salaries>>> GetAllSalaries()
    {
        var salarysList = await _salaryService.GetAll();

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok(salarysList);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Salaries>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetSalaryById(Guid id)
    {
        if (!(await _salaryService.IsExist(id)))
        {
            return NotFound();
        }

        var salary = _mapper.Map<SalaryResponse>(await _salaryService.GetById(id));

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(salary);
    }

    [HttpPost]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Salaries>))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Task<Salaries>>> AddSalary([FromBody] SalaryRequest salary)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _salaryService.AddSalary(salary);
        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteSalary(Guid id)
    {
        if (!(await _salaryService.IsExist(id)))
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        await _salaryService.DeleteSalary(id);
        return Ok("Successfully Deleted");
    }

    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<Task<Salaries>>> UpdateSalary(Guid id, [FromBody] SalaryRequest salary)
    {
        if (!(await _salaryService.IsExist(id)))
            return NotFound();
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var updateSalary = await _salaryService.UpdateSalary(id, salary);
        return Ok(updateSalary);

    }
}
}
