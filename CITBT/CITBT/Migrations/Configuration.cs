namespace CITBT.Migrations
{
    using CITBT.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CITBT.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(CITBT.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Roles.AddOrUpdate(
                r => r.Name,
                new IdentityRole() { Id = "1", Name = "Admin" },
                new IdentityRole() { Id = "2", Name = "User" },
                new IdentityRole() { Id = "3", Name = "EventOrganizer" },
                new IdentityRole() { Id = "4", Name = "Tester" }
            );
            context.SaveChanges();

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var passwordHash = new PasswordHasher();
                string password = passwordHash.HashPassword("admin@123");

                var user = new ApplicationUser { UserName = "admin", PasswordHash = password, SecurityStamp = Guid.NewGuid().ToString() };

                context.Users.AddOrUpdate(u => u.UserName, user);
                context.SaveChanges();
                //manager.Create(user, "admin@123");
                manager.AddToRole(user.Id, "Admin");

                ApplicationUserManager userManager = new ApplicationUserManager(store);
                userManager.AddUserToSpecific(user.Id, "Admin");
            }
        }
    }
}
