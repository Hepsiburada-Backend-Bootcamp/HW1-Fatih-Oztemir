using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HW1_Fatih_Oztemir.Models
{
    public class Department
    {
        [Required(ErrorMessage = "Please enter id")]
        public int Id { get; set; }
        [StringLength(2, ErrorMessage ="Please enter the valid length(2,20) Department name",MinimumLength =20)]
        public string DepartmentName { get; set; }
    }
}
