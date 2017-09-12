using GarbagePickup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarbagePickup.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();

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
            return View();
        }

        public ActionResult Employee()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
}