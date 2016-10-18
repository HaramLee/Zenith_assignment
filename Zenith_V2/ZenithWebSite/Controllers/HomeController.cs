using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Model;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var today = DateTime.Now;
            var events = db.Events.Include(a => a.Activity).Include(b => b.ApplicationUser);
            var stuff = events.ToList();
            var send = new List<Event>();
            var datelist = new List<DateTime>();
            var someDay = today;
            var week = new TimeSpan(6, 23, 59, 59);

            if (today.DayOfWeek != DayOfWeek.Monday)
            {
                while (true)
                {
                    someDay = someDay.AddDays(-1);            //go backwards 1 day
                    if (someDay.DayOfWeek == DayOfWeek.Monday)
                    {
                        break;
                    }
                }
            }

            var lastMonday = someDay.Date;
            foreach (var x in stuff)
            {

                if (x.FromDate >= lastMonday && x.FromDate <= lastMonday + week)
                {

                    if (!datelist.Contains(x.FromDate))
                        datelist.Add(x.FromDate);

                    send.Add(x);

                }


            }
            datelist.Sort();
            ViewData["MyData"] = datelist;

            return View(send);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}