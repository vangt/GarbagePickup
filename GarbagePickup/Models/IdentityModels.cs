﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;

namespace GarbagePickup.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string Zip { get; set; }

        public ScheduleList scheduleList { get; set; }
        public int ScheduleId { get; set; }
        public string Day { get; set; }

        public int Weeks { get; set; }
        
        public string LeavingDate { get; set; }
        public string ReturningDate { get; set; }

        public string Role { get; set; }

        public ApplicationUser applicationUsers { get; set; }

        public IEnumerable<ScheduleList> Schedules { get; set; }

        public IEnumerable<ApplicationUser> CustomerUsers { get; set; }

        public string TempZip { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<ScheduleList> ScheduleLists { get; set; }
    }
}