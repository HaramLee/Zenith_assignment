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
            var events = db.Events.Include(a=> a.Activity).Include(b => b.ApplicationUser);
            var stuff = events.ToList();
            var send = new List<Event>();
            

            foreach(var x in stuff)
            {
                var diffPast = today - x.DateCreated;
                var diffFuture = x.DateCreated - today;
                var week = new TimeSpan(6, 23, 59, 59);
                if (diffPast <= week)
                {
                    send.Add(x);

                }
            }
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