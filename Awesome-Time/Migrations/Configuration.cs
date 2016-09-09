namespace Awesome_Time.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Entities;
    using Microsoft.AspNet.Identity;
    using Awesome_Time.Services;
    using Awesome_Time.Interfaces;

    internal sealed class Configuration : DbMigrationsConfiguration<Awesome_Time.Entities.ApplicationDbContext>
    {
        
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Awesome_Time.Entities.ApplicationDbContext";
        }

        protected override void Seed(Awesome_Time.Entities.ApplicationDbContext context)
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

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            #region Administrator Account
            //Add initial administrator account
            var administratorAccount = new ApplicationUser
            {
                UserName = "adimistrator@ggbg.com",
                Email = "adimistrator@ggbg.com",
                PhoneNumber = "555555555",
                AwesomenessNumber = "2016BA-123EN",
                TwitterAccount = "nottwitter",
                GivenName = "Gandalf",
                FamilyName = "The Administrator",
                RegistrationDate = DateTime.Now
            };

            userManager.Create(administratorAccount, "Administrator55");
            //User Id is not populated by IF
            administratorAccount.Id = context.Users.FirstOrDefault(x => x.UserName == administratorAccount.UserName).Id;

            var administratorRole = new IdentityRole
            {
                Name = "Administrator"
            };

            //Seed roles
            roleManager.Create(administratorRole);

            userManager.AddToRole(administratorAccount.Id, administratorRole.Name);
            #endregion
        }
    }
}
