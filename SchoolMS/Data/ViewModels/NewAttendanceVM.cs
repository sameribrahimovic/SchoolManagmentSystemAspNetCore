using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolMS.Data.ViewModels
{
    public class NewAttendanceVM
    {

        public int Id { get; set; }

        //Relationships

        [Required(ErrorMessage = "Course is requiered")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Student is requiered")]
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
