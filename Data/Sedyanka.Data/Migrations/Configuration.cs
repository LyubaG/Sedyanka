namespace MvcTemplate.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using MvcTemplate.Common;
    using MvcTemplate.Data.Models;
    using System;
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            // TODO switch in production
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }

            //Random rand = new Random();

            //for (int i = 0; i < 10; i++)
            //{
            //    Joke laptop = new Joke();
            //    Joke.
            //    laptop.HardDiskSize = rand.Next(10, 1000);
            //    laptop.ImageUrl = "http://laptop.bg/system/images/26207/thumb/toshiba_satellite_l8501v8.jpg";
            //    laptop.Manufacturer = sampleManufacturer;
            //    laptop.Model = "ideapad";
            //    laptop.MonitorSize = 15.4;
            //    laptop.Price = rand.Next(600, 3000);
            //    laptop.RamMemorySize = rand.Next(1, 16);
            //    laptop.Weight = 3;

            //    var votesCount = rand.Next(0, 10);
            //    for (int j = 0; j < votesCount; j++)
            //    {
            //        laptop.Votes.Add(new Vote { Laptop = laptop, VotedBy = user });
            //    }

            //    var commentsCount = rand.Next(0, 10);
            //    for (int j = 0; j < commentsCount; j++)
            //    {
            //        laptop.Comments.Add(new Comment { Content = "Mnou qk laptop brat.", Author = user });
            //    }

            //    context.Laptops.Add(laptop);
            //}

            //context.SaveChanges();

            //base.Seed(context);
        }
    }
}
