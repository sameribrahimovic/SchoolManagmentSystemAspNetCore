using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolMS.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }

        //Relationships

        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

    }
}
