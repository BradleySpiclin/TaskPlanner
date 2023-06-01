using Microsoft.AspNetCore.Mvc;
using TaskPlanner.Models;

namespace TaskPlanner.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
