namespace ZenithDataLib.Migrations.ZenithData
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithDataLib.Model.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ZenithData";
        }

        protected override void Seed(ZenithDataLib.Model.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            if (!roleManager.RoleExists("Member"))
                roleManager.Create(new IdentityRole("Member"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            string[] emails = { "a@a.a", "m@m.m" };
            string[] userNames = { "a", "m" };

            if (userManager.FindByEmail(emails[0]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[0],
                    UserName = userNames[0],
                    FirstName = userNames[0],
                    LastName = userNames[0],
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
            }
            if (userManager.FindByEmail(emails[1]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[1],
                    UserName = userNames[1],
                    FirstName = userNames[1],
                    LastName = userNames[1],
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Member");
            }

            context.Activities.AddOrUpdate(t => t.ActivityId, getActivities().ToArray());
            context.SaveChanges();

            context.Events.AddOrUpdate(p => p.EventId, getEvents(context).ToArray());
            context.SaveChanges();

        }

        private List<Activity> getActivities()
        {

            string Text = "27/09/2016";
            DateTime myDate1 = DateTime.ParseExact(Text, "dd/MM/yyyy", null);

            Text = "28/09/2016";
            DateTime myDate2 = DateTime.ParseExact(Text, "dd/MM/yyyy", null);

            Text = "30/09/2016";
            DateTime myDate3 = DateTime.ParseExact(Text, "dd/MM/yyyy", null);

            List<Activity> activities = new List<Activity>();
            activities.Add(new Activity()
            {
                ActivityDec = "Senior’s Golf Tournament",
                DateCreated = myDate1
            });
            activities.Add(new Activity()
            {
                ActivityDec = "Leadership General Assembly Meeting",
                DateCreated = myDate2
            });
            activities.Add(new Activity()
            {
                ActivityDec = "Youth Bowling Tournament",
                DateCreated = myDate3
            });
            activities.Add(new Activity()
            {
                ActivityDec = "Young ladies cooking lessons",
                DateCreated = myDate3
            });
            return activities;
        }

        private List<Event> getEvents(ZenithDataLib.Model.ApplicationDbContext db)
        {

            TimeSpan FTime = new TimeSpan(08, 30, 0);
            TimeSpan TTime = new TimeSpan(10, 30, 0);

            string Text = "27/09/2016";
            DateTime myDate1 = DateTime.ParseExact(Text, "dd/MM/yyyy", null);

            Text = "28/09/2016";
            DateTime myDate2 = DateTime.ParseExact(Text, "dd/MM/yyyy", null);

            Text = "30/09/2016";
            DateTime myDate3 = DateTime.ParseExact("30/09/2016", "dd/MM/yyyy", null);
            //Convert.ToDateTime("2016/09/10");

            List<Event> events = new List<Event>();
            events.Add(new Model.Event
            {
                FromDate = FTime,
                ToDate = TTime,
                DateCreated = myDate1,
                ApplicationUser = db.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Senior’s Golf Tournament")
            });

            events.Add(new Model.Event
            {
                FromDate = FTime,
                ToDate = TTime,
                DateCreated = myDate2,
                ApplicationUser = db.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Leadership General Assembly Meeting")
            });

            events.Add(new Model.Event
            {
                FromDate = FTime,
                ToDate = TTime,
                DateCreated = myDate3,
                ApplicationUser = db.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Youth Bowling Tournament")
            });

            return events;
        }
    }
}

