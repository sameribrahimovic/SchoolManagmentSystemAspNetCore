using SchoolMS.Data.Base;
using SchoolMS.Models;

namespace SchoolMS.Data.Services
{
    public class StudentsService : EntityBaseRepository<Student>, IStudentsService
    {
        public StudentsService(ApplicationDbContext context) : base(context) { }
    }
}
