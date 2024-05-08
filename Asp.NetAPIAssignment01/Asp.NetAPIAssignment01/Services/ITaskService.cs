using Asp.NetAPIAssignment01.Model;

namespace Asp.NetAPIAssignment01.Services
{
    public interface ITaskService
    {
        TaskModel CreateTask(TaskModel task);
        List<TaskModel> GetAllTasks();
        TaskModel GetTaskByID(string taskId);
        void DeleteTask(string id);
        TaskModel UpdateTask(string id, TaskModel taskModel);
        void AddBulkTasks(List<TaskModel> tasksList);
        string DeleteBulkTasks(List<string> ids);
    }
}
