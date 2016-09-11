using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INEQ.Models
{
    public class ComponentType
    {
        public int ID { get; set; }
        public String Description { get; set; }
        public Activator Active { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}