using TaskPlanner.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace TaskPlanner.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
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
