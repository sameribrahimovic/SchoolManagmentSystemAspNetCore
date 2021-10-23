using Microsoft.AspNetCore.Mvc;

namespace SchoolMS.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
