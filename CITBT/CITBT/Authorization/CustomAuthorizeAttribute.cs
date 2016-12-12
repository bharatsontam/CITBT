using CITBT.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CITBT
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var context = new ApplicationDbContext();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            bool result = true;
            Roles.Split(',').ToList().ForEach(role =>
            {
                if (!userManager.IsInRole(httpContext.User.Identity.GetUserId(), role))
                {
                    result = false;
                }
            });
            return result;

            //return base.AuthorizeCore(httpContext);
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                if (filterContext.HttpContext.Request.Url != null)
                {
                    filterContext.Result = new RedirectResult("~/Account/UnAuthorized?ReturnUrl=" + System.Web.HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.AbsolutePath), true);
                }
            }
        }
    }
}