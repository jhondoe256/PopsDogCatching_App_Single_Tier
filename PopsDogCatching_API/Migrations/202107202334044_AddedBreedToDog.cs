namespace PopsDogCatching_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBreedToDog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dogs", "BreedID", c => c.Int(nullable: false));
            CreateIndex("dbo.Dogs", "BreedID");
            AddForeignKey("dbo.Dogs", "BreedID", "dbo.Breeds", "ID", cascadeDelete: true);
            DropColumn("dbo.Dogs", "Breed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dogs", "Breed", c => c.String());
            DropForeignKey("dbo.Dogs", "BreedID", "dbo.Breeds");
            DropIndex("dbo.Dogs", new[] { "BreedID" });
            DropColumn("dbo.Dogs", "BreedID");
        }
    }
}
