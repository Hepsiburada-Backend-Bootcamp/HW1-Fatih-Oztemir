using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HW1_Fatih_Oztemir.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Please enter id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "please enter the your name")]
        [MinLength(3, ErrorMessage = "your name must be more than 2 letters")]
        [MaxLength(20, ErrorMessage = "your name must be less than 20 letters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please enter the your surname")]
        [MinLength(3, ErrorMessage = "your surname must be more than 2 letters")]
        [MaxLength(20, ErrorMessage = "your surname must be less than 20 letters")]
        public string Surname { get; set; }
        public int DepartmentId { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
