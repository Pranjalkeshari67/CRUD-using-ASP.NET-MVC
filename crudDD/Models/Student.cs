using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace crudDD.Models
{
    public class Student
    {
        [Required]
        public string stu_id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Guardian_Name { get; set; }
        [Required]
        public int Class_id { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Admission_date { get; set; }
    }
}