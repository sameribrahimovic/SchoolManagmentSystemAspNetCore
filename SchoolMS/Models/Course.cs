using SchoolMS.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace SchoolMS.Models
{
    public class Course : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        public string Price { get; set; }
    }
}
