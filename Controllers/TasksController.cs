using TaskPlanner.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaskPlanner.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allTasks = await _service.GetAllAsync();
            return View(allTasks);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
