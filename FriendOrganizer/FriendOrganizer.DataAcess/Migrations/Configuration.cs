namespace FriendOrganizer.DataAcess.Migrations
{
    using FriendOrganizer.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganizer.DataAcess.FriendOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganizer.DataAcess.FriendOrganizerDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Friends.AddOrUpdate(
                f => f.Id,
                new Friend { FirstName = "Ahmed", LastName = "Ali" },
                new Friend { FirstName = "Mohammed", LastName = "Ibrahim" },
                new Friend { FirstName = "Omar", LastName = "Khairy" },
                new Friend { FirstName = "Basem", LastName = "Gamal" }
                );
        }
    }
}
