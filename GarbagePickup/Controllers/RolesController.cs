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

        [HttpGet]
        public ActionResult Schedule()
        {
            var schedulelist = context.ScheduleLists.Select(x => x).ToList();
            var username = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == username).First();
            user.Schedules = schedulelist;

            return View(user);
        }

        [HttpPost]
        public ActionResult Schedule(ApplicationUser user)
        {
            var userName = User.Identity.GetUserName();
            var userInfo = context.Users.Where(x => x.UserName == userName).First();
            userInfo.Weeks = user.Weeks;
            userInfo.Day = user.Day;
            userInfo.LeavingDate = user.LeavingDate;
            userInfo.ReturningDate = user.ReturningDate;
            context.SaveChanges();

            return RedirectToAction("Index", "Roles");
        }

        [HttpGet]
        public ActionResult CustomerProfile()
        {
            var username = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == username).First();
            return View(user);
        }

        [HttpPost]
        public ActionResult CustomerProfile(ApplicationUser user)
        {
            var userName = User.Identity.GetUserName();
            var userInfo = context.Users.Where(x => x.UserName == userName).First();
            userInfo.FirstName = user.FirstName;
            userInfo.LastName = user.LastName;
            userInfo.StreetAddress = user.StreetAddress;
            userInfo.Zip = user.Zip;
            userInfo.PhoneNumber = user.PhoneNumber;
            userInfo.Email = user.Email;
            context.SaveChanges();

            return RedirectToAction("Index", "Roles");
        }

        [HttpGet]
        public ActionResult FindCustomers()
        {
            var username = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == username).First();

            return View(user);
        }

        [HttpPost]
        public ActionResult FindCustomers(string tempZip)
        {
            var role = context.Roles.Where(x => x.Name == "Customer").Select(x=>x.Id).ToString();
            var customers = context.Users.Where(x => x.Zip == tempZip).ToList();
            var username = User.Identity.GetUserName();
            var user = context.Users.Where(x => x.UserName == username).First();
            user.CustomerUsers = customers;
            var users = user.CustomerUsers.ToList();
            var newCustomers = PossibleCustomers(users);
            user.TempZip = tempZip;

            return View(customers);
        }

        public List<ApplicationUser> PossibleCustomers(List<ApplicationUser> list)
        {
            var role = context.Roles.Where(x => x.Name == "Customer").Select(x => x.Id).ToList();
            string rolecheck = role.First();
            var users = list;
            var newUsers = new List<ApplicationUser>();

            foreach (var c in users)
            {
                if (c.Roles.Select(x => x.RoleId).ToString() == rolecheck)
                {
                    newUsers.Add(c);
                }
            }

            return newUsers;
        }
    }
}