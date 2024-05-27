using Asp.NetAPIAssignment01.Model;

namespace Asp.NetAPIAssignment01.Repositories
{
    public interface ITaskRepository
    {
        TaskModel CreateTask(TaskModel task);
        List<TaskModel> GetAllTasks();
        TaskModel GetTaskByID(string id);
        void DeleteTask(string id);
        void DeleteBulkTasks(List<TaskModel> tasksList);

    }
}
