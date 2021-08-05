namespace PopsDogCatching_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Breeds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BreedName = c.String(nullable: false),
                        Section = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DateOfBirth = c.DateTimeOffset(nullable: false, precision: 7),
                        CaptureDate = c.DateTimeOffset(nullable: false, precision: 7),
                        BreedID = c.Int(),
                        HasCollarIdentification = c.Boolean(nullable: false),
                        HasChipIdentification = c.Boolean(nullable: false),
                        WasFoundInjured = c.Boolean(nullable: false),
                        DogTemperment = c.Int(nullable: false),
                        DogInjurySeverity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Breeds", t => t.BreedID)
                .Index(t => t.BreedID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
            DropForeignKey("dbo.Dogs", "BreedID", "dbo.Breeds");
            DropIndex("dbo.RouteEmployees", new[] { "Employee_ID" });
            DropIndex("dbo.RouteEmployees", new[] { "Route_ID" });
            DropIndex("dbo.Dogs", new[] { "BreedID" });
            DropTable("dbo.RouteEmployees");
            DropTable("dbo.Routes");
            DropTable("dbo.Employees");
            DropTable("dbo.Dogs");
            DropTable("dbo.Breeds");
        }
    }
}
