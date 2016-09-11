using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversityAPI.Models
{
    public class Course
    {
        public int ID { get; set; }
        public String Tittle { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Student> Enrollment { get; set; }

    }
}