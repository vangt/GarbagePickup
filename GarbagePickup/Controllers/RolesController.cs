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
            var customer = context.Users.Select(m => m.UserName);
            return View(customer);
        }

        public ActionResult Employee()
        {
            var employee = context.Users.Select(m => m.UserName);
            return View(employee);
        }

        public ActionResult Admin()
        {
            var admin = context.Users.Select(m => m.UserName);
            var username = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == username).First();
            return View(user);
        }
    }
}