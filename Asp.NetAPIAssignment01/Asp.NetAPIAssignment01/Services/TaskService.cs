using Asp.NetAPIAssignment01.Model;
using Asp.NetAPIAssignment01.Repositories;

namespace Asp.NetAPIAssignment01.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ILogger<TaskService> _logger;
        public TaskService(ILogger<TaskService> logger, ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
            _logger = logger;
        }

        public TaskModel CreateTask(TaskModel task)
        {
            task.Id = Guid.NewGuid().ToString();
            return _taskRepository.CreateTask(task);
        }
        public TaskModel GetTaskByID(string id) 
        {
            TaskModel? task = null;
            try
            {
                task = _taskRepository.GetTaskByID(id);
                if (task == null) throw new Exception("Task Not Found ");
            }
            catch (Exception e) {
                _logger.LogError(e.Message);
            }
            return task;
        }
        public void DeleteTask(string id)
        {
            try
            {
                TaskModel task = _taskRepository.GetTaskByID(id);
                if (task == null) {
                    throw new Exception("Task Not Found "); 
                }else
                {
                    _taskRepository.DeleteTask(id);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            
        }

        public List<TaskModel> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public TaskModel UpdateTask(string id, TaskModel taskModel)
        {
            TaskModel? task = null;
            try
            {
                task = _taskRepository.GetTaskByID(id);
                if (task == null)
                {
                    throw new Exception("Task Not Found ");
                }
                task.Title = taskModel.Title ?? task.Title;
                if (task.Completed != taskModel.Completed)
                    task.Completed = taskModel.Completed;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return task;
        }

        public void AddBulkTasks(List<TaskModel> tasksList)
        {
            List<TaskModel> newTasks = tasksList.Select(task => new TaskModel
            {
                Id = Guid.NewGuid().ToString(),
                Title = task.Title,
                Completed = task.Completed,
            }).ToList();
            _taskRepository.GetAllTasks().AddRange(newTasks);
        }

        public string DeleteBulkTasks(List<string> ids)
        {
            List<TaskModel> foundTasksList = new List<TaskModel>();
            List<string> notFoundIdsList = new List<string>();
            List<TaskModel> allTasksList = _taskRepository.GetAllTasks();
                foreach (string id in ids)
                {
                    TaskModel? task = allTasksList.FirstOrDefault(t => t.Id == id);
                    if (task != null)
                    {
                        foundTasksList.Add(task);
                    }
                    else 
                    {
                    notFoundIdsList.Add(id);
                    }
                }
            _taskRepository.DeleteBulkTasks(foundTasksList);
            int foundTask = ids.Count - notFoundIdsList.Count;
            if (notFoundIdsList.Count > 0 && notFoundIdsList.Count < ids.Count)
            {
                string message = $"Deleted {foundTask} tasks \n Not found {notFoundIdsList.Count} id{(notFoundIdsList.Count == 1 ? "" : "s")}:" +
                                 string.Join(", ", notFoundIdsList);
                return message;
            }
            else if (notFoundIdsList.Count > ids.Count)
            {
                return "Not found all entered ids";
            }
            else return $"Deleted {foundTask} task{(foundTask==1?"":"s")}";
        }
    }
}
