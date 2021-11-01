using Microsoft.EntityFrameworkCore;
using SchoolMS.Models;
using SchoolMS.Data.ViewModels;

namespace SchoolMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<SchoolMS.Data.ViewModels.NewAttendanceVM> NewAttendanceVM { get; set; }
    }
}
