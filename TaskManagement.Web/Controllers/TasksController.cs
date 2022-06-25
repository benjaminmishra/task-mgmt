using Microsoft.AspNetCore.Mvc;

namespace TaskManagement.Web.Controllers
{
    public class TasksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
