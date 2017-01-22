using AutoMapper;
using CITBT.Models;
using CITBT.Models.DbModels;
using CITBT.Repository;
using CITBT.ViewModels.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CITBT.ViewModels.Purchase;

namespace CITBT.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public EventsController()
        {

        }
        public EventsController(ApplicationUserManager userManager, ApplicationDbContext context)
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

        // GET: Events
        public ActionResult Index()
        {
            var repo = new Repository<Event>();
            var events = repo.GetAll;

            if (CheckUserRole.IsUserInRole(User.Identity.GetUserId(), "EventOrganizer"))
            {
                events = repo.GetAll.Where(x => x.UserId == User.Identity.GetUserId());
            }

            var model = Mapper.Map<IEnumerable<Event>, IEnumerable<EventViewModel>>(events);

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new CreateEventViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateEventViewModel model, HttpPostedFileBase imagefile = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var _event = Mapper.Map<CreateEventViewModel, Event>(model);

            if (imagefile != null)
            {
                _event.FileName = imagefile.FileName;
                _event.ContentType = imagefile.ContentType;
                //movie.Image
                _event.Image = new byte[imagefile.ContentLength];
                imagefile.InputStream.Read(_event.Image, 0, imagefile.ContentLength);
            }
            _event.UserId = UserManager.Users.Where(u => u.UserName == User.Identity.Name).Select(x => x.Id).FirstOrDefault();
            var result = new Event();
            using (var eventRepo = new Repository<Event>())
            {
                result = eventRepo.InsertOrUpdate(_event);

            }
            return RedirectToAction("Detail", new { id = result.Id });
        }

        public ActionResult Edit(Guid id)
        {
            using (var eventRepo = new Repository<Event>())
            {
                var _event = eventRepo.GetById(id);
                var model = Mapper.Map<Event, EditEventViewModel>(_event);

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(EditEventViewModel model, HttpPostedFileBase imagefile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var _event = Mapper.Map<EditEventViewModel, Event>(model);


            _event.UserId = UserManager.Users.Where(u => u.UserName == User.Identity.Name).Select(x => x.Id).FirstOrDefault();
            var result = new Event();
            using(var repo = new Repository<Event>())
            using (var eventRepo = new Repository<Event>())
            {
                if (imagefile != null)
                {
                    _event.FileName = imagefile.FileName;
                    _event.ContentType = imagefile.ContentType;
                    _event.Image = new byte[imagefile.ContentLength];
                    imagefile.InputStream.Read(_event.Image, 0, imagefile.ContentLength);
                }
                else
                {
                    var _value = repo.GetById(model.Id);
                    _event.FileName = _value.FileName;
                    _event.ContentType = _value.ContentType;
                    _event.Image = _value.Image;
                }
                result = eventRepo.InsertOrUpdate(_event);

            }
            return RedirectToAction("Detail", new { id = result.Id });
        }

        public ActionResult Detail(Guid id, string message = null)
        {
            ViewBag.Message = message;

            using (var eventRepo = new Repository<Event>())
            {
                var _event = eventRepo.GetById(id);
                var model = Mapper.Map<Event, EventDetailViewModel>(_event);

                ViewBag.BookingOpened = _event.BookingOpenEvents.Count > 0;
                ViewBag.PreBookingOpened = _event.PreBookingEvents.Count > 0;

                return View(model);
            }
        }

        public ActionResult Delete(Guid id)
        {
            using (var eventRepo = new Repository<Event>())
            {
                var _event = eventRepo.GetById(id);
                eventRepo.Remove(_event);
                return RedirectToAction("Index");
            }
        }
    }
    [Authorize]
    public class EventRegisterController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public EventRegisterController()
        {

        }
        public EventRegisterController(ApplicationUserManager userManager, ApplicationDbContext context)
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

        public ActionResult Create(Guid eventId)
        {
            var model = new CreatePurchasedEventsViewModel();
            model.EventId = eventId;
            model.UserId = User.Identity.GetUserId();
            using (var eventrepo = new Repository<Event>())
            {
                var _event = eventrepo.GetById(model.EventId);
                model.EventName = _event.Name;
                model.EntryFee = _event.EntryFee;
            }
            var user = UserManager.Users.Where(x => x.Id == model.UserId).FirstOrDefault();
            model.UserName = user.FirstName + " " + user.LastName;
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreatePurchasedEventsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = Mapper.Map<CreatePurchasedEventsViewModel, UserRegisteredEvents>(model);

            using (var repo = new Repository<UserRegisteredEvents>())
            {
                result = repo.InsertOrUpdate(result);
            }

            return RedirectToAction("Detail", new { id = result.Id });
        }

        public ActionResult Detail(Guid id)
        {
            using (var repo = new Repository<UserRegisteredEvents>())
            {
                var result = repo.GetById(id);

                var model = Mapper.Map<UserRegisteredEvents, PurchasedEventsViewModel>(result);

                using (var eventrepo = new Repository<Event>())
                {
                    var _event = eventrepo.GetById(model.EventId);
                    model.EventName = _event.Name;
                    model.EntryFee = _event.EntryFee;
                }
                var user = UserManager.Users.Where(x => x.Id == model.UserId).FirstOrDefault();
                model.UserName = user.FirstName + " " + user.LastName;

                return View(model);
            }
        }

        [Authorize]
        public ActionResult Delete(Guid id)
        {
            using (var cancelRepo = new Repository<UserEventCancellationRequests>())
            using (var repo = new Repository<UserRegisteredEvents>())
            {
                var result = repo.GetById(id);

                result.IsCancelled = true;
                result.IsRefunded = false;

                result = repo.InsertOrUpdate(result);

                var cancelRequest = new UserEventCancellationRequests
                {
                    IsApproved = false,
                    IsRefunded = false,
                    EventId = result.EventId,
                    RequestedDate = DateTime.Now,
                    UserEventRegisteredId = result.Id,
                    UserId = result.UserId
                };

                var canceResult = cancelRepo.InsertOrUpdate(cancelRequest);

                return RedirectToAction("UserHome", "Home");
            }
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Approve(Guid id)
        {
            using (var cancelRepo = new Repository<UserEventCancellationRequests>())
            using (var repo = new Repository<UserRegisteredEvents>())
            {
                var cancelRequest = cancelRepo.GetById(id);

                var movieRequest = repo.GetById(cancelRequest.UserEventRegisteredId);

                movieRequest.IsRefunded = true;
                repo.InsertOrUpdate(movieRequest);

                cancelRequest.ProcessedUserId = new Guid(User.Identity.GetUserId());
                cancelRequest.ProcessedDate = DateTime.Now;
                cancelRequest.IsApproved = true;
                cancelRequest.IsRefunded = true;

                cancelRepo.InsertOrUpdate(cancelRequest);

                return RedirectToAction("Admin", "Home");
            }
        }
    }
    [Authorize]
    public class EventCancellationController : Controller
    {
        public ActionResult Index()
        {
            using (var repo = new Repository<UserEventCancellationRequests>())
            {
                var model = repo.GetAll;
                return View(model);
            }
        }
    }
}