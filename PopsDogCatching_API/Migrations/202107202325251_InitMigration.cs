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
                        BreedName = c.String(),
                        Section = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.DateTimeOffset(nullable: false, precision: 7),
                        CaptureDate = c.DateTimeOffset(nullable: false, precision: 7),
                        Breed = c.String(),
                        HasCollarIdentification = c.Boolean(nullable: false),
                        HasChipIdentification = c.Boolean(nullable: false),
                        WasFoundInjured = c.Boolean(nullable: false),
                        DogTemperment = c.Int(nullable: false),
                        DogInjurySeverity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
            DropTable("dbo.Dogs");
            DropTable("dbo.Breeds");
        }
    }
}
