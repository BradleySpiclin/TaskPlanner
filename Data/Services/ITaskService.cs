using TaskPlanner.Data.Base;
using TaskPlanner.Models;

namespace TaskPlanner.Data.Services
{
    public interface ITaskService : IEntityBaseRepository<TaskItem>
    {
    }
}
