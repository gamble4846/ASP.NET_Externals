using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Externals_20MCA097.Models
{
    public class Student
    {
        public int id { get; set; }
        [Required]
        public string fname { get; set; }
        [Required]
        public string course { get; set; }
        [Required]
        public int year { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}