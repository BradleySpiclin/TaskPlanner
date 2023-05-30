using TaskPlanner.Data.Services;
using Microsoft.AspNetCore.Mvc;
using TaskPlanner.Models;

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

        // POST: Tasks/Create/
        [HttpPost]
        public async Task<IActionResult> Create([Bind("UnitCode,TaskName,TaskComments,TaskDueDate")] TaskItem task)
        {
            if (!ModelState.IsValid)
                return View(task);

            await _service.AddAsync(task);
            return RedirectToAction(nameof(Index));
        }

        // Get request
        public async Task<IActionResult> Details(int id)
        {
            var taskDetails = await _service.GetByIdAsync(id);
            if (taskDetails == null)
                return View("NotFound");

            return View(taskDetails);
        }


        // GET: Tasks/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var taskDetails = await _service.GetByIdAsync(id);
            if (taskDetails == null)
                return View("NotFound");

            return View(taskDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskItem task)
        {
            if (!ModelState.IsValid)
                return View(task);

            var existingTask = await _service.GetByIdAsync(id);
            if (existingTask == null)
                return NotFound();

            existingTask.UnitCode = task.UnitCode;
            existingTask.Name = task.Name;
            existingTask.Comments = task.Comments;
            existingTask.DueDate = task.DueDate;
            existingTask.IsComplete = task.IsComplete;
            existingTask.CompletedDate = task.CompletedDate;

            await _service.UpdateAsync(id, existingTask);
            return RedirectToAction(nameof(Index));
        }

        // GET: Tasks/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var taskDetails = await _service.GetByIdAsync(id);
            if (taskDetails == null)
                return View("NotFound");

            return View(taskDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskDetails = await _service.GetByIdAsync(id);
            if (taskDetails == null)
                return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
