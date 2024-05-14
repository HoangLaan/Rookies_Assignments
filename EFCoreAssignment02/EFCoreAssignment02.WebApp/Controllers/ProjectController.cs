using AutoMapper;
using EFCoreAssignment02.Infrastructure.Interfaces;
using EFCoreAssignment02.Infrastructure.ModelDto;
using EFCoreAssignment02.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment02.WebApp.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public IMapper _mapper;

        public ProjectController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Projects>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<Projects>>> GetAllProjects()
        {
            var projectssList = await _projectService.GetAll();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(projectssList);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Projects>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            if (!(await _projectService.IsExist(id)))
            {
                return NotFound();
            }

            var project = _mapper.Map<ProjectResponse>(await _projectService.GetById(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(project);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Projects>))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Task<Projects>>> AddProject([FromBody] ProjectRequest project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _projectService.AddProject(project);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteProject(Guid id)
        {
            if (!(await _projectService.IsExist(id)))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _projectService.DeleteProject(id);
            return Ok("Successfully Deleted");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Task<Projects>>> UpdateProject(Guid id, [FromBody] ProjectRequest project)
        {
            if (!(await _projectService.IsExist(id)))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updateProject = await _projectService.UpdateProject(id, project);
            return Ok(updateProject);

        }
    }
}
