namespace PopsDogCatching_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRouteID_to_Employee_and_EmployeeID_to_Route : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "RouteID", c => c.Int(nullable: true));
            AddColumn("dbo.Routes", "EmployeeID", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Routes", "EmployeeID");
            DropColumn("dbo.Employees", "RouteID");
        }
    }
}
