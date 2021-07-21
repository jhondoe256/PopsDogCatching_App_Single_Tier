namespace PopsDogCatching_API.Migrations
{
    using PopsDogCatching_API.Models.Utilities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PopsDogCatching_API.Models.DbContexts.PopsDogCatchingDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PopsDogCatching_API.Models.DbContexts.PopsDogCatchingDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var listOfBreeds = CsvReader.ReadAllBreeds().OrderBy(b=>b.BreedName);
           
            context.Breeds.AddOrUpdate(b => b.BreedName, listOfBreeds.ToArray());
        }
    }
}
