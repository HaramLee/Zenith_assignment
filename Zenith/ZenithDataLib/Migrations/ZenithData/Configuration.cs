namespace ZenithDataLib.Migrations.ZenithData
{
    using Model.ZenithModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithDataLib.Model.ZenithModel.ActivityEventContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ZenithData";
        }

        protected override void Seed(ZenithDataLib.Model.ZenithModel.ActivityEventContext context)
        {
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

        private List<Event> getEvents(ActivityEventContext db)
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
            events.Add(new Model.ZenithModel.Event
            {
                FromDate = FTime,
                ToDate = TTime,
                DateCreated = myDate1,
                Activity = db.Activities.First(t => t.ActivityDec == "Senior’s Golf Tournament")
            });

            events.Add(new Model.ZenithModel.Event
            {
                FromDate = FTime,
                ToDate = TTime,
                DateCreated = myDate2,
                Activity = db.Activities.First(t => t.ActivityDec == "Leadership General Assembly Meeting")
            });

            events.Add(new Model.ZenithModel.Event
            {
                FromDate = FTime,
                ToDate = TTime,
                DateCreated = myDate3,
                Activity = db.Activities.First(t => t.ActivityDec == "Youth Bowling Tournament")
            });

            return events;
        }
    }
}
