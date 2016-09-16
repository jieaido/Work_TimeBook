using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Entity.Model;

namespace Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
       [Authorize]
        public ActionResult About()
       {
           string re = "";
           if (User.Identity.IsAuthenticated)
           {
               FormsIdentity id = (FormsIdentity) User.Identity;
               var ticket = id.Ticket;
               re = ticket.UserData;
           }
            ViewBag.Message = re;

            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}