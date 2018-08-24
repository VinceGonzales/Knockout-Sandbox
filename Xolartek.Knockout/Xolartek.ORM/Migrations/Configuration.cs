using System.Data.Entity.Migrations;
using Xolartek.Core.Fortnite;

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
            if (context.Database.Exists())
            {
                context.Rarities.AddOrUpdate(r => r.Description,
                    new Rarity() { Description = "Common" },
                    new Rarity() { Description = "Epic" },
                    new Rarity() { Description = "Legendary" },
                    new Rarity() { Description = "Mythic" },
                    new Rarity() { Description = "Rare" });
            }
        }
    }
}
