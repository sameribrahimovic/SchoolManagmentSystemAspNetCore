using SchoolMS.Data.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolMS.Models
{
    public class Student : IEntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required!")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Contact is required!")]
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
