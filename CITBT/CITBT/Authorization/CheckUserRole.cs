using CITBT.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CITBT
{
    public static class CheckUserRole
    {
        public static bool IsUserInRole(string userId, string role)
        {
            var context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            return userManager.IsInRole(userId, role);
        }
    }
}