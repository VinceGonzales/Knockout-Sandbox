using System.Data.Entity.Migrations;

namespace Xolartek.ORM.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Xolartek.ORM.XolarDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Xolartek.ORM.XolarDatabase context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
