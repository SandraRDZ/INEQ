using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContosoUniversityAPI.Models
{
    public class SchoolContext : DbContext
    {

        public SchoolContext(): base ("School Context")
        {

        }

    }
}