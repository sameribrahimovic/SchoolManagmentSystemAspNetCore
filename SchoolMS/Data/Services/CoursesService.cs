using SchoolMS.Data.Base;
using SchoolMS.Models;

namespace SchoolMS.Data.Services
{
    public class CoursesService : EntityBaseRepository<Course>, ICoursesService
    {
        public CoursesService(ApplicationDbContext context) : base(context) { }
    }
}
