using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebSite.Data;

namespace ZenithWebSite.Models
{
    public class InitialData
    {

        public static void Initialize(ApplicationDbContext context, ZenithContext z)
        {

            //context.context.Activities.Add(t => t.ActivityId, getActivities().ToArray());
            getActivities(z);
            //context.Add(t => t.ActivityId, getActivities(context).ToArray());
            z.SaveChanges();

            //context.db.Events.Add(p => p.EventId, getEvents(context).ToArray());
            getEvents(z, context);
            z.SaveChanges();

            initializeRoles(context);
        }

        private static async void initializeRoles(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var adminRole = await roleStore.FindByNameAsync("Admin");
            if(adminRole == null)
            {
                adminRole = new IdentityRole("Admin");
                await roleStore.CreateAsync(adminRole);
            }
            var memberRole = await roleStore.FindByNameAsync("Member");
            if (memberRole == null)
            {
                memberRole = new IdentityRole("Member");
                await roleStore.CreateAsync(memberRole);
            }

            var userStore = new UserStore<ApplicationUser>(context);
            string[] emails = { "a@a.a", "m@m.m" };
            string[] userNames = { "a", "m" };
            if(userStore.FindByEmailAsync(emails[0]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[0],
                    UserName = userNames[0],
                    FirstName = userNames[0],
                    LastName = userNames[0],
                };
                var result = userStore.CreateAsync(user);

                var password = new PasswordHasher<ApplicationUser>();
                password.HashPassword(user, "P@$$w0rd");
            }

            if(userStore.FindByEmailAsync(emails[1]) == null)
            {
                var user = new ApplicationUser
                {
                    Email = emails[1],
                    UserName = userNames[1],
                    FirstName = userNames[1],
                    LastName = userNames[1],
                };
                var result = userStore.CreateAsync(user);
                var password = new PasswordHasher<ApplicationUser>();
                password.HashPassword(user, "P@$$w0rd");
            }

        }

        private static List<Activity> getActivities(ZenithContext context)
        {

            string Text = "18/10/2016";
            DateTime myDate1 = DateTime.ParseExact(Text, "dd/MM/yyyy", null);

            Text = "19/10/2016";
            DateTime myDate2 = DateTime.ParseExact(Text, "dd/MM/yyyy", null);

            Text = "20/10/2016";
            DateTime myDate3 = DateTime.ParseExact(Text, "dd/MM/yyyy", null);


            List<Activity> activities = new List<Activity>();
            context.Activities.Add(new Activity()
            {
                ActivityDec = "Senior’s Golf Tournament",
                DateCreated = myDate1
            });
            context.Activities.Add(new Activity()
            {
                ActivityDec = "Leadership General Assembly Meeting",
                DateCreated = myDate2
            });
            context.Activities.Add(new Activity()
            {
                ActivityDec = "Youth Bowling Tournament",
                DateCreated = myDate3
            });
            context.Activities.Add(new Activity()
            {
                ActivityDec = "Young ladies cooking lessons",
                DateCreated = myDate3
            });
            context.Activities.Add(new Activity()
            {
                ActivityDec = "Youth craft lessons",
                DateCreated = myDate3
            });
            context.Activities.Add(new Activity()
            {
                ActivityDec = "Youth choir practice",
                DateCreated = myDate3
            });
            context.Activities.Add(new Activity()
            {
                ActivityDec = "Lunch",
                DateCreated = myDate3
            });
            context.Activities.Add(new Activity()
            {
                ActivityDec = "Pancake Breakfast",
                DateCreated = myDate3
            });
            context.Activities.Add(new Activity()
            {
                ActivityDec = "Swimming Lessons for the youth",
                DateCreated = myDate3
            });
            context.Activities.Add(new Activity()
            {
                ActivityDec = "Swimming Exercise for parents",
                DateCreated = myDate3
            });
            context.Activities.Add(new Activity()
            {
                ActivityDec = "Bingo Tournament",
                DateCreated = myDate3
            });
            context.Activities.Add(new Activity()
            {
                ActivityDec = "BBQ Lunch",
                DateCreated = myDate3
            });
            context.Activities.Add(new Activity()
            {
                ActivityDec = "Garage Sale",
                DateCreated = myDate3
            });
            return activities;
        }

        private static List<Event> getEvents(ZenithContext db, ApplicationDbContext context)
        {

            TimeSpan FTime = new TimeSpan(08, 30, 0);
            TimeSpan TTime = new TimeSpan(10, 30, 0);

            string Text = "09/27/2016";
            DateTime myDate1 = DateTime.ParseExact(Text, "MM/dd/yyyy", null);

            Text = "09/28/2016";
            DateTime myDate2 = DateTime.ParseExact(Text, "MM/dd/yyyy", null);

            Text = "09/29/2016";
            DateTime myDate3 = DateTime.ParseExact(Text, "MM/dd/yyyy", null);
            //Convert.ToDateTime("2016/09/10");

            List<Event> events = new List<Event>();
            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/18/2016 08:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/18/2016 10:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate1,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Senior’s Golf Tournament")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/19/2016 08:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/19/2016 10:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate2,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Leadership General Assembly Meeting")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/21/2016 17:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/21/2016 19:15", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Youth Bowling Tournament")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/21/2016 19:00", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/21/2016 20:00", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Young ladies cooking lessons")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/22/2016 08:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/22/2016 10:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Youth craft lessons")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/22/2016 10:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/22/2016 12:00", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Youth choir practice")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/22/2016 12:00", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/22/2016 13:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Lunch")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/23/2016 07:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/23/2016 08:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Pancake Breakfast")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/23/2016 08:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/23/2016 10:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Swimming Lessons for the youth")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/23/2016 08:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/23/2016 10:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Swimming Exercise for parents")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/23/2016 10:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/23/2016 12:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Bingo Tournament")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/23/2016 12:00", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/23/2016 13:00", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "BBQ Lunch")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/23/2016 13:00", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/23/2016 18:00", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Garage Sale")
            });

            //Next week

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/25/2016 08:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/25/2016 10:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate1,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Senior’s Golf Tournament")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/26/2016 08:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/26/2016 10:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate2,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Leadership General Assembly Meeting")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/28/2016 17:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/28/2016 19:15", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Youth Bowling Tournament")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/28/2016 19:00", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/28/2016 20:00", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Young ladies cooking lessons")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/29/2016 08:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/29/2016 10:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Youth craft lessons")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/29/2016 10:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/29/2016 12:00", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Youth choir practice")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/29/2016 12:00", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/29/2016 13:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Lunch")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/30/2016 07:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/30/2016 08:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Pancake Breakfast")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/30/2016 08:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/30/2016 10:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Swimming Lessons for the youth")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/30/2016 08:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/30/2016 10:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Swimming Exercise for parents")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/30/2016 10:30", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/30/2016 12:30", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Bingo Tournament")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/30/2016 12:00", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/30/2016 13:00", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "BBQ Lunch")
            });

            db.Events.Add(new Event
            {
                FromDate = DateTime.ParseExact("10/30/2016 13:00", "MM/dd/yyyy HH:mm", null),
                ToDate = DateTime.ParseExact("10/30/2016 18:00", "MM/dd/yyyy HH:mm", null),
                DateCreated = myDate3,
                ApplicationUser = context.Users.First(a => a.UserName == "a"),
                Activity = db.Activities.First(t => t.ActivityDec == "Garage Sale")
            });

            return events;
        }
    }
}
