using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMS.Data.Services;
using SchoolMS.Data.ViewModels;
using System.Threading.Tasks;

namespace SchoolMS.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly IAttendancesService _service;
        public AttendancesController(IAttendancesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allAttendances = await _service.GetAllAsync(n => n.Student);
            return View(allAttendances);
        }

        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var attendanceDropdownsData = await _service.GetNewAttendanceDropdownsValues();

            ViewBag.Students = new SelectList(attendanceDropdownsData.Students, "Id", "Name");
            ViewBag.Courses = new SelectList(attendanceDropdownsData.Courses, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewAttendanceVM attendance)
        {
            if (!ModelState.IsValid)
            {
                var attendanceDropdownsData = await _service.GetNewAttendanceDropdownsValues();

                ViewBag.Students = new SelectList(attendanceDropdownsData.Students, "Id", "Name");
                ViewBag.Courses = new SelectList(attendanceDropdownsData.Courses, "Id", "Name");

                return View(attendance);
            }

            await _service.AddNewAttendanceAsync(attendance);
            return RedirectToAction(nameof(Index));
        }
    }
}
