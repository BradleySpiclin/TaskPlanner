using TaskPlanner.Data.Base;
using TaskPlanner.Models;

namespace TaskPlanner.Data.Services
{
    public class TaskService : EntityBaseRepository<TaskItem>, ITaskService
    {
        public TaskService(AppDbContext context) : base(context) { }
    }
}
