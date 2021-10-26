using SchoolMS.Models;
using System.Collections.Generic;

namespace SchoolMS.Data.ViewModels
{
    public class NewAttendanceDropdownsVM
    {
        public NewAttendanceDropdownsVM()
        {
            Courses = new List<Course>();
            Students = new List<Student>();
        }
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
    }
}
