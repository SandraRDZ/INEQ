using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversityAPI.Models
{
    public class Student
    {

        int ID { get; set; }
        String FirstName { get; set; }
        String FamilyName { get; set; }
        DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        
    }


}