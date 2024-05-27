using Asp.NetAPIAssignment01.Model;
using Asp.NetAPIAssignment01.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Asp.NetAPIAssignment01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public IActionResult CreateTask(TaskModel task)
        {
            _taskService.CreateTask(task);
            return Ok(task);
        }

        [HttpGet]
        public List<TaskModel> GetTasks()
        {
            return _taskService.GetAllTasks();
        }
        [HttpGet("{id}")]
        public TaskModel GetTaskById(string id) 
        {
            return _taskService.GetTaskByID(id);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTasks(string id) {
            _taskService.DeleteTask(id);
            return Ok($"Deleted Task with id: {id}");
        }

        [HttpPut("{id}")]
        public TaskModel UpdateTask(string id, [FromBody] TaskModel taskModel)
        {
            return _taskService.UpdateTask(id, taskModel);
        }

        [HttpPost("BulkAdd")]
        public IActionResult BulkAddTask([FromBody] List<TaskModel> tasksList)
        {
            _taskService.AddBulkTasks(tasksList);
            return Ok($"Added {tasksList.Count} tasks");
        }

        [HttpDelete("BulkDelete")]
        public IActionResult BulkDeleteTask([FromBody] List<string> ids)
        {
            return Ok(_taskService.DeleteBulkTasks(ids));
        }
    }
}
