using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAspMvc.Models
{
    public class Faculty
    {
        [Key]
        [Required(ErrorMessage = "FacultyId is Required!")]
        public int FacultyId { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }
    }
}