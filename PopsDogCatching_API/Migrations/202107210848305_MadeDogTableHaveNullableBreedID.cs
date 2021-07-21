namespace PopsDogCatching_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeDogTableHaveNullableBreedID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dogs", "BreedID", "dbo.Breeds");
            DropIndex("dbo.Dogs", new[] { "BreedID" });
            AlterColumn("dbo.Breeds", "BreedName", c => c.String(nullable: false));
            AlterColumn("dbo.Dogs", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Dogs", "BreedID", c => c.Int());
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            CreateIndex("dbo.Dogs", "BreedID");
            AddForeignKey("dbo.Dogs", "BreedID", "dbo.Breeds", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dogs", "BreedID", "dbo.Breeds");
            DropIndex("dbo.Dogs", new[] { "BreedID" });
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Dogs", "BreedID", c => c.Int(nullable: false));
            AlterColumn("dbo.Dogs", "Name", c => c.String());
            AlterColumn("dbo.Breeds", "BreedName", c => c.String());
            CreateIndex("dbo.Dogs", "BreedID");
            AddForeignKey("dbo.Dogs", "BreedID", "dbo.Breeds", "ID", cascadeDelete: true);
        }
    }
}
