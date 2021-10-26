using Microsoft.EntityFrameworkCore;
using SchoolMS.Data.Base;
using SchoolMS.Data.ViewModels;
using SchoolMS.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMS.Data.Services
{
    public class AttendancesService : EntityBaseRepository<Attendance>, IAttendancesService
    {
        private readonly ApplicationDbContext _context;
        public AttendancesService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewAttendanceAsync(NewAttendanceVM data)
        {
            var newAttendance = new Attendance()
            {
                CourseId = data.CourseId,
                StudentId = data.StudentId
            };
            await _context.Attendances.AddAsync(newAttendance);
            await _context.SaveChangesAsync();
        }

        public async Task<Attendance> GetAttendanceByIdAsync(int id)
        {
            var attendanceDetails = await _context.Attendances
                .Include(c => c.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(n => n.Id == id);

            return attendanceDetails;
        }

        public async Task<NewAttendanceDropdownsVM> GetNewAttendanceDropdownsValues()
        {
            var response = new NewAttendanceDropdownsVM()
            {
                Courses = await _context.Courses.OrderBy(c => c.Name).ToListAsync(),
                Students = await _context.Students.OrderBy(s => s.Name).ToListAsync()
            };
            return response;
        }

        public async Task UpdateAttendanceAsync(NewAttendanceVM data)
        {
            var dbAttendance = await _context.Attendances.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbAttendance != null)
            {
                dbAttendance.CourseId = data.CourseId;
                dbAttendance.StudentId = data.StudentId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
