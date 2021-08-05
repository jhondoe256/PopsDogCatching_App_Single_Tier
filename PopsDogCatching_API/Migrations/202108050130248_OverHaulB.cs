namespace PopsDogCatching_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverHaulB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Routes", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Routes", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Routes", "Description", c => c.String());
            AlterColumn("dbo.Routes", "Address", c => c.String());
        }
    }
}
