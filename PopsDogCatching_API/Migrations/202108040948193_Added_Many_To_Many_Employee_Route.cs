namespace PopsDogCatching_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_Many_To_Many_Employee_Route : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RouteEmployees",
                c => new
                    {
                        Route_ID = c.Int(nullable: false),
                        Employee_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Route_ID, t.Employee_ID })
                .ForeignKey("dbo.Routes", t => t.Route_ID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_ID, cascadeDelete: true)
                .Index(t => t.Route_ID)
                .Index(t => t.Employee_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RouteEmployees", "Employee_ID", "dbo.Employees");
            DropForeignKey("dbo.RouteEmployees", "Route_ID", "dbo.Routes");
            DropIndex("dbo.RouteEmployees", new[] { "Employee_ID" });
            DropIndex("dbo.RouteEmployees", new[] { "Route_ID" });
            DropTable("dbo.RouteEmployees");
            DropTable("dbo.Routes");
        }
    }
}
