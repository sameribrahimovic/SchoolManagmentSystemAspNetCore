using Microsoft.AspNetCore.Mvc;
using SchoolMS.Data.Services;
using SchoolMS.Models;
using System.Threading.Tasks;

namespace SchoolMS.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService _service;
        public StudentsController(IStudentsService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            //show all courses from database
            var data = await _service.GetAllAsync();
            return View(data);
        }
        //Get: Students/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Address,City,Contact,Email,Gender,DateAdded")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            await _service.AddAsync(student);
            return RedirectToAction(nameof(Index));
        }

        //Get: Students/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var studentDetails = await _service.GetByIdAsync(id);
            if (studentDetails == null) return View("NotFound");
            return View(studentDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,City,Contact,Email,Gender,DateAdded")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }
            await _service.UpdateAsync(id, student);
            return RedirectToAction(nameof(Index));
        }


    }
}
