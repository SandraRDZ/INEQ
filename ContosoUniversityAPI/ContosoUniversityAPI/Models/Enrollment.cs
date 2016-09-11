using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversityAPI.Models
{
    public class Enrollment
    {

        int ID { get; set; }
        int StudentID { get; set; }
        int CourseID { get; set; }
        char Grade { get; set; }



            public virtual ICollection<Course> Enrollments { get; set; }



    }
}