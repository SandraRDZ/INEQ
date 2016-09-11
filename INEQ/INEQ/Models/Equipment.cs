using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace INEQ.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        public int StatusID { get; set; }
        public String EquipmentTypeld { get; set; }
        public String Modelld {get; set;}
        public String Brandld { get; set; }
        public int WarehouseId { get; set; }
        public DateTime EntryDate { get; set; }
        public int Serie { get; set; }
        public int SofttekId { get; set; }
        public Activator Active { get; set; }

        public virtual ICollection<Statu> Status { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
        public virtual ICollection<ComponentType> ComponentTypes { get; set; }
    }
}