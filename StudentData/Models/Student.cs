using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentData.Models
{
    internal class Student
    {
        
            public int Id { get; set; }
        [Required]
            public string Name { get; set; }
        [Required]
        public string Speciality { get; set; }
       
    }
}
