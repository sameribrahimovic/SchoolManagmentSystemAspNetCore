using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolMS.Data;
using SchoolMS.Data.Services;
using SchoolMS.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMS.Controllers
{
    public class AttendancesController : Controller
    {
        private readonly IAttendancesService _service;
        private readonly IStudentsService _studentsService;
        private readonly ApplicationDbContext _context;
        public AttendancesController(IAttendancesService service, IStudentsService studentsService, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
            _studentsService = studentsService;
        }
        public async Task<IActionResult> Index()
        {
            var allAttendances = await _service.GetAllAsync(n => n.Student, n => n.Course);
            return View(allAttendances);
        }

        #region
        //GET: Attendances/Create
        //public async Task<IActionResult> Create()
        //{
        //    var attendanceDropdownsData = await _service.GetNewAttendanceDropdownsValues();

        //    ViewBag.Students = new SelectList(attendanceDropdownsData.Students, "Id", "Name");
        //    ViewBag.Courses = new SelectList(attendanceDropdownsData.Courses, "Id", "Name");

        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(NewAttendanceVM attendance)
        //{
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    var attendanceDropdownsData = await _service.GetNewAttendanceDropdownsValues();

        //    //    ViewBag.Students = new SelectList(attendanceDropdownsData.Students, "Id", "Name");
        //    //    ViewBag.Courses = new SelectList(attendanceDropdownsData.Courses, "Id", "Name");

        //    //    return View(attendance);
        //    //}

        //    await _service.AddNewAttendanceAsync(attendance);
        //    return RedirectToAction(nameof(Index));
        //}
        #endregion



        public async Task<IActionResult> Create(Attendance model)
        {
            var student = _context.Students.SingleOrDefault(
                s => s.Id == model.Id);

            var courses = _context.Courses.SingleOrDefault(
                c => c.Id == model.Id);

            var newAttendance = new Attendance
            {
                Student = student,
                Course = courses,
                DateAdded = DateTime.Now
            };

            _context.Attendances.Add(newAttendance);
            _context.SaveChanges();
            return View(newAttendance);
        }

        //Get: Attendance/Create
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("Name,Price")] Attendance attendance)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(attendance);
        //    }
        //    await _service.AddAsync(attendance);
        //    return RedirectToAction(nameof(Index));
        //}

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchStudent()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();

                var names = _context.Students.Where(p => p.Name.Contains(term)).Select(p => p.Name).ToListAsync();
                return Ok(await names);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SearchCourse()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();

                var names = _context.Courses.Where(p => p.Name.Contains(term)).Select(p => p.Name).ToListAsync();
                return Ok(await names);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        //public async Task<IActionResult> Filter(string searchString)
        //{
        //    var allStudents = await _studentsService.GetAllAsync(n => n.Name);

        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        var filteredResult = allStudents.Where(n => n.Name.Contains(searchString) || n.Contact.Contains(searchString)).ToList();
        //        return View("Index", filteredResult);
        //    }

        //    return View("Index", allStudents);
        //}
    }
}
