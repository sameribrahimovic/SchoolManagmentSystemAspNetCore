using Microsoft.AspNetCore.Mvc;
using SchoolMS.Data.Services;
using SchoolMS.Models;
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
        //Get: Courses/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name, Price")] Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            await _service.AddAsync(course);
            return RedirectToAction(nameof(Index));
        }

        //Get: Courses/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var courseDetails = await _service.GetByIdAsync(id);
            if (courseDetails == null) return View("NotFound");
            return View(courseDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }
            await _service.UpdateAsync(id, course);
            return RedirectToAction(nameof(Index));
        }


    }
}
