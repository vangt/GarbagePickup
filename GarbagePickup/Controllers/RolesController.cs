using GarbagePickup.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GarbagePickup.Controllers
{
    public class RolesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Roles
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Customer"))
                {
                    return RedirectToAction("Customer");
                }
                else if (User.IsInRole("Employee"))
                {
                    return RedirectToAction("Employee");
                }
                else if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Admin");
                }
                else
                {
                    return View("Index", "Home");
                }
            }
            else
            {
                return View("Index", "Home");
            }
        }

        public ActionResult Customer()
        {
            var username = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == username).First();
            return View(user);
        }

        public ActionResult Employee()
        {
            var username = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == username).First();
            return View(user);
        }

        public ActionResult Admin()
        {
            var username = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == username).First();
            return View(user);
        }

        public ActionResult Schedule()
        {
            var sc = context.ScheduleLists.Select(x => x).ToList();
            var username = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == username).First();
            user.Schedules = sc;

            return View(user);
        }
    }
}