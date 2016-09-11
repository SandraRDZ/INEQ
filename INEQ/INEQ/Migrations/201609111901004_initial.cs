namespace INEQ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComponentType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Equipment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StatusID = c.Int(nullable: false),
                        EquipmentTypeld = c.String(),
                        Modelld = c.String(),
                        Brandld = c.String(),
                        WarehouseId = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        Serie = c.Int(nullable: false),
                        SofttekId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Statu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Warehouse",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        IS = c.String(),
                        Responsable = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.EquipmentComponentType",
                c => new
                    {
                        Equipment_ID = c.Int(nullable: false),
                        ComponentType_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Equipment_ID, t.ComponentType_ID })
                .ForeignKey("dbo.Equipment", t => t.Equipment_ID, cascadeDelete: true)
                .ForeignKey("dbo.ComponentType", t => t.ComponentType_ID, cascadeDelete: true)
                .Index(t => t.Equipment_ID)
                .Index(t => t.ComponentType_ID);
            
            CreateTable(
                "dbo.StatuEquipment",
                c => new
                    {
                        Statu_ID = c.Int(nullable: false),
                        Equipment_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Statu_ID, t.Equipment_ID })
                .ForeignKey("dbo.Statu", t => t.Statu_ID, cascadeDelete: true)
                .ForeignKey("dbo.Equipment", t => t.Equipment_ID, cascadeDelete: true)
                .Index(t => t.Statu_ID)
                .Index(t => t.Equipment_ID);
            
            CreateTable(
                "dbo.WarehouseEquipment",
                c => new
                    {
                        Warehouse_ID = c.Int(nullable: false),
                        Equipment_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Warehouse_ID, t.Equipment_ID })
                .ForeignKey("dbo.Warehouse", t => t.Warehouse_ID, cascadeDelete: true)
                .ForeignKey("dbo.Equipment", t => t.Equipment_ID, cascadeDelete: true)
                .Index(t => t.Warehouse_ID)
                .Index(t => t.Equipment_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarehouseEquipment", "Equipment_ID", "dbo.Equipment");
            DropForeignKey("dbo.WarehouseEquipment", "Warehouse_ID", "dbo.Warehouse");
            DropForeignKey("dbo.StatuEquipment", "Equipment_ID", "dbo.Equipment");
            DropForeignKey("dbo.StatuEquipment", "Statu_ID", "dbo.Statu");
            DropForeignKey("dbo.EquipmentComponentType", "ComponentType_ID", "dbo.ComponentType");
            DropForeignKey("dbo.EquipmentComponentType", "Equipment_ID", "dbo.Equipment");
            DropIndex("dbo.WarehouseEquipment", new[] { "Equipment_ID" });
            DropIndex("dbo.WarehouseEquipment", new[] { "Warehouse_ID" });
            DropIndex("dbo.StatuEquipment", new[] { "Equipment_ID" });
            DropIndex("dbo.StatuEquipment", new[] { "Statu_ID" });
            DropIndex("dbo.EquipmentComponentType", new[] { "ComponentType_ID" });
            DropIndex("dbo.EquipmentComponentType", new[] { "Equipment_ID" });
            DropTable("dbo.WarehouseEquipment");
            DropTable("dbo.StatuEquipment");
            DropTable("dbo.EquipmentComponentType");
            DropTable("dbo.Warehouse");
            DropTable("dbo.Statu");
            DropTable("dbo.Equipment");
            DropTable("dbo.ComponentType");
        }
    }
}
