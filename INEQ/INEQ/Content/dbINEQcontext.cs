using INEQ.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace INEQ.Content
{
    public class dbINEQcontext: DbContext
    {
        public dbINEQcontext(): base ("dbINEQ")
        {
        }
        public DbSet<Statu> Status { get; set; }
        public DbSet<Equipment> Equipment { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<INEQ.Models.ComponentType> ComponentTypes { get; set; }

        public System.Data.Entity.DbSet<INEQ.Models.Warehouse> Warehouses { get; set; }
    }
}