using SchoolMS.Data.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolMS.Models
{
    public class Attendance : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        //Relationships


        public int CourseId { get; set; }
        public Course Course { get; set; }


        public int StudentId { get; set; }
        public Student Student { get; set; }

        public DateTime DateAdded { get; set; } = DateTime.Now;

    }
}
