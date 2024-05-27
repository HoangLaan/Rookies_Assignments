using Asp.NetAPIAssignment01.Model;

namespace Asp.NetAPIAssignment01.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        List<TaskModel> tasksList = new List<TaskModel>();
        public List<TaskModel> GetAllTasks()
        {
            return tasksList;
        }
        public TaskModel CreateTask(TaskModel task)
        {
            TaskModel newTask = new TaskModel
            {
                Id = task.Id,
                Title = task.Title,
                Completed = task.Completed
            };
            tasksList.Add(newTask);
            return task;
        }
        public void DeleteTask(string id)
        {
            tasksList.Remove(GetTaskByID(id));
        }
        public TaskModel GetTaskByID(string id)
        {
            var task = (from t in tasksList
                        where t.Id == id
                        select t).FirstOrDefault();
            return task;
        }

        public void DeleteBulkTasks(List<TaskModel> tasks)
        {
            foreach (var task in tasks)
            {
                tasksList.Remove(task);
            }
            
        }
    }
}
