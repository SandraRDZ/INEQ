using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INEQ.Models
{
    public class Principal
    {

        public String Descripcion { get; set; }

        public virtual ICollection<Statu> Status { get; set; }

    }
}