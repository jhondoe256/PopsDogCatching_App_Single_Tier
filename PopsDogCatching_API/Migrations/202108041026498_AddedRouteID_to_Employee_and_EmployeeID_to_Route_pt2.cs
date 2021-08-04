namespace PopsDogCatching_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRouteID_to_Employee_and_EmployeeID_to_Route_pt2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "RouteID", c => c.Int());
            AlterColumn("dbo.Routes", "EmployeeID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Routes", "EmployeeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "RouteID", c => c.Int(nullable: false));
        }
    }
}
