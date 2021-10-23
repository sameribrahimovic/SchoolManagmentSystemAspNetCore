using Microsoft.AspNetCore.Mvc;
using SchoolMS.Data.Services;
using System.Threading.Tasks;

namespace SchoolMS.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesService _service;
        public CoursesController(ICoursesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            //show all courses from database
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }
    }
}
