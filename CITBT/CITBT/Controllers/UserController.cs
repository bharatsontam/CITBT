using CITBT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CITBT.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;
        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationDbContext context)
        {
            UserManager = userManager;
            Context = context;
        }
        public ApplicationDbContext Context
        {
            get
            {
                return _context ?? new ApplicationDbContext();
            }
            private set
            {
                _context = value;
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: User
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = new List<UserViewModel>();
            foreach (var user in UserManager.Users)
            {
                var _user = new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName
                };
                model.Add(_user);
            }
            return View(model);
        }

        public ActionResult Details(string id)
        {
            var user = UserManager.Users.Where(u => u.Id == id).FirstOrDefault();
            var model = new UserDetailsViewModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                SelectedRoles = user.Roles.Select(r => (r.RoleId == "1" ? "Admin" : (r.RoleId == "2" ? "User" : (r.RoleId == "3" ? "EventOrganizer" : "Tester")))).ToList(),
                UserName = user.UserName
            };

            return View(model);
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            var user = UserManager.Users.Where(u => u.Id == id).FirstOrDefault();
            var model = new EditUserDetailsViewModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                SelectedRoles = user.Roles.Where(u => u.UserId == user.Id).Select(r => (r.RoleId == "1" ? "Admin" : (r.RoleId == "2" ? "User" : (r.RoleId == "3" ? "EventOrganizer" : "Tester")))).ToList(),
                UserName = user.UserName,
                AvailableRoles = new List<string> { "Admin", "User", "EventOrganizer","Tester" }
            };

            return View(model);
        }

        [CustomAuthorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Edit(EditUserDetailsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = UserManager.Users.Where(u => u.Id == model.Id).FirstOrDefault();
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;

            var userRoles = user.Roles.Where(u => u.UserId == model.Id).Select(r => r.RoleId);

            var _roles = new List<string>();

            userRoles.ToList().ForEach(x =>
            {
                switch (x)
                {
                    case "1":
                        _roles.Add("Admin");
                        break;
                    case "2":
                        _roles.Add("User");
                        break;
                    case "3":
                        _roles.Add("EventOrganizer");
                        break;
                    case "4":
                        _roles.Add("Tester");
                        break;
                }
            });
            await this.UserManager.RemoveFromRolesAsync(model.Id, _roles.ToArray());

            await this.UserManager.AddToRolesAsync(model.Id, model.SelectedRoles.ToArray());

            this.UserManager.AddUserToSpecific(user.Id, model.SelectedRoles.FirstOrDefault());

            await this.UserManager.UpdateAsync(user);

            return RedirectToAction("Details", new { id = model.Id });
        }

        [CustomAuthorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            var model = new CreateUserViewModel();
            return View(model);
        }

        [CustomAuthorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword(model.Password);

            var userStore = new UserStore<ApplicationUser>(Context);
            var userManager = new ApplicationUserManager(userStore);

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await userManager.CreateAsync(user, model.Password);

            userManager.AddUserToSpecific(user.Id, model.SelectedRoles.FirstOrDefault());

            foreach (var selectedRole in model.SelectedRoles)
            {
                userManager.AddToRole(user.Id, selectedRole);
            }

            return RedirectToAction("Index");
        }
    }
}