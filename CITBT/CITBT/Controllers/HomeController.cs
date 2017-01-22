using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CITBT.Models.DbModels;
using CITBT.Repository;
using AutoMapper;
using CITBT.ViewModels.Events.EventRequests;
using CITBT.Models;
namespace CITBT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (CheckUserRole.IsUserInRole(User.Identity.GetUserId(), "Admin"))
                {
                    return RedirectToAction("Admin");
                }
                else if (CheckUserRole.IsUserInRole(User.Identity.GetUserId(), "EventOrganizer"))
                {
                    return RedirectToAction("Organizer");
                }
                else if (CheckUserRole.IsUserInRole(User.Identity.GetUserId(), "User"))
                {
                    return RedirectToAction("UserHome");
                }
            }
            return View();
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

        public ActionResult UserHome()
        {
            return View();
        }

        public ActionResult Organizer()
        {
            return View();
        }

        public ActionResult Admin()
        {
            return View();
        }
    }
    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public AdminController()
        {

        }
        public AdminController(ApplicationUserManager userManager, ApplicationDbContext context)
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
        public JsonResult GetEventUpdateRequests()
        {
            using (var repo = new Repository<EventRequests>())
            {
                var eventRequests = repo.GetAll.Where(x => !x.IsApproved);

                var result = eventRequests.Select(x => new { RequestedOrganizer = x.Organizer.FirstName + " " + x.Organizer.LastName, EventName = x.Event.Name, Id = x.Id });

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEventCancellationRequests()
        {
            using (var repo = new Repository<UserEventCancellationRequests>())
            {
                var eventCancellationRequests = repo.GetAll.Where(x => !x.IsApproved);

                var result = eventCancellationRequests.Select(x => new
                {
                    Id = x.Id,
                    Name = UserManager.Users.Where(y => y.Id == x.User.UserId.ToString()).Select(z => z.FirstName + " " + z.LastName).FirstOrDefault(),
                    EventName = x.Event.Name,
                    EventDateTime = x.Event.EventDateTime.HasValue ? x.Event.EventDateTime.Value.ToShortDateString() : string.Empty,
                    EntryFee = x.Event.EntryFee,
                    PurchasePrice = x.UserRegisteredEvent.PurchasePrice
                });

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetMovieCancellationRequests()
        {
            using (var repo = new Repository<UserMovieCancellationRequests>())
            {
                var movieCancellationRequests = repo.GetAll.Where(x => !x.IsApproved);

                var result = movieCancellationRequests.Select(x => new
                {
                    Id = x.Id,
                    Name = UserManager.Users.Where(y => y.Id == x.User.UserId.ToString()).Select(z => z.FirstName + " " + z.LastName).FirstOrDefault(),
                    MovieName = x.Movie.MovieName,
                    ReleaseDate = x.Movie.ReleaseDate.HasValue ? x.Movie.ReleaseDate.Value.ToShortDateString() : string.Empty,
                    MoviePrice = x.UserPurchasedMovie.PurchasePrice,
                    PurchasePrice = x.UserPurchasedMovie.PurchasePrice
                });

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetUpdates()
        {
            using (var purchasedMoviesRepo = new Repository<UserPurchasedMovies>())
            using (var registeredEventsRepo = new Repository<UserRegisteredEvents>())
            using (var bookingOpenEventsRepo = new Repository<BookingOpenEvent>())
            using (var bookingOpenMoviesRepo = new Repository<BookingOpenMovie>())
            {
                var purchasedMoviesCount = purchasedMoviesRepo.GetAll.Where(x => !x.IsCancelled).Count();
                var registeredEventsCount = registeredEventsRepo.GetAll.Where(x => !x.IsCancelled).Count();
                var bookingOpenEventsCount = bookingOpenEventsRepo.GetAll.Count();
                var bookingOpenMoviesCount = bookingOpenMoviesRepo.GetAll.Count();

                return Json(new
                {
                    PurchasedMoviesCount = purchasedMoviesCount,
                    RegisteredEventsCount = registeredEventsCount,
                    BookingOpenEventsCount = bookingOpenEventsCount,
                    BookingOpenMoviesCount = bookingOpenMoviesCount
                }, JsonRequestBehavior.AllowGet);
            }
        }

    }
    [Authorize]
    public class UserHomeController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public UserHomeController()
        {

        }
        public UserHomeController(ApplicationUserManager userManager, ApplicationDbContext context)
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

        public JsonResult GetBookedMovies()
        {
            using (var repo = new Repository<UserPurchasedMovies>())
            {
                var result = repo.GetAll.Where(x => x.User.UserId == new Guid(User.Identity.GetUserId()) && !x.IsCancelled).Select(y =>
                new
                {
                    MovieName = y.Movie.MovieName,
                    Id = y.Id
                });

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetUpcomingMovies()
        {
            using (var repo = new Repository<BookingOpenMovie>())
            {
                var result = repo.GetAll.Select(x =>
                new
                {
                    Id = x.MovieId,
                    Image = x.Movie.Image != null ? Convert.ToBase64String(x.Movie.Image) : null
                });
                var JsonResult = Json(result, JsonRequestBehavior.AllowGet);
                JsonResult.MaxJsonLength = int.MaxValue;
                return JsonResult;
            }
        }

        public JsonResult GetUpComingEvents()
        {
            using (var repo = new Repository<BookingOpenEvent>())
            {
                var result = repo.GetAll.Select(x => new
                {
                    Id = x.EventId,
                    Image = x.Event.Image != null ? Convert.ToBase64String(x.Event.Image) : null
                });
                var JsonResult = Json(result, JsonRequestBehavior.AllowGet);
                JsonResult.MaxJsonLength = int.MaxValue;
                return JsonResult;
            }
        }

        public JsonResult GetRegisteredEvents()
        {
            using (var repo = new Repository<UserRegisteredEvents>())
            {
                var result = repo.GetAll.Where(x => x.User.UserId == new Guid(User.Identity.GetUserId()) && !x.IsCancelled).Select(y =>
                new
                {
                    EventName = y.Event.Name,
                    Id = y.Id
                });

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
    [Authorize]
    public class OrganizerController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public OrganizerController()
        {

        }
        public OrganizerController(ApplicationUserManager userManager, ApplicationDbContext context)
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

        public JsonResult GetEventRequestsPending()
        {
            using (var repo = new Repository<EventRequests>())
            {
                var model = repo.GetAll.Where(x => !x.IsApproved);

                var result = model.Select(x => new
                {
                    EventName = x.Event.Name,
                    RequestedDate = x.RequestDate,
                    Id = x.Id
                });

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEventRequestsApproved()
        {
            using (var repo = new Repository<EventRequests>())
            {
                var model = repo.GetAll.Where(x => x.IsApproved);

                var result = model.Select(x => new
                {
                    EventName = x.Event.Name,
                    RequestedDate = x.RequestDate.HasValue ? x.RequestDate.Value.ToShortDateString() : string.Empty,
                    ProcessedDate = x.ProcessedDate.HasValue ? x.ProcessedDate.Value.ToShortDateString() : string.Empty
                });

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetOrganizerUpdates()
        {
            using (var repo = new Repository<UserRegisteredEvents>())
            using (var eventOpenRepo = new Repository<BookingOpenEvent>())
            {
                var registerEventsCount = repo.GetAll.Where(x => !x.IsCancelled && x.Event.UserId == User.Identity.GetUserId()).Count();
                var eventsOpenedCount = eventOpenRepo.GetAll.Where(x => x.Event.UserId == User.Identity.GetUserId()).Count();

                var result = new
                {
                    UserRegisteredEventsCount = registerEventsCount,
                    OpenedEventsCount = eventsOpenedCount
                };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }
    }
}