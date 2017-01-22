using CITBT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CITBT.ViewModels.Events;
using AutoMapper;
using CITBT.ViewModels.Events.EventRequests;
using CITBT.Models.DbModels;
using CITBT.Repository;

namespace CITBT.Controllers
{
    [Authorize]
    public class EventRequestController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public EventRequestController()
        {

        }
        public EventRequestController(ApplicationUserManager userManager, ApplicationDbContext context)
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
        // GET: EventRequest
        public ActionResult Index()
        {
            using (var repo = new Repository<EventRequests>())
            {
                var eventRequests = repo.GetAll;

                var model = Mapper.Map<IEnumerable<EventRequests>, IEnumerable<EventRequestViewModel>>(eventRequests);
                return View(model);
            }
        }

        


        [HttpPost]
        public ActionResult Create(EditEventViewModel model)
        {
            var createEventRequest = Mapper.Map<EditEventViewModel, CreateEventRequestViewModel>(model);
            var eventRequest = Mapper.Map<CreateEventRequestViewModel, EventRequests>(createEventRequest);
            eventRequest.OrganizerId = (User.Identity.GetUserId());
            eventRequest.ProcessedUserId = null;
            var result = new EventRequests();
            using (var repo = new Repository<EventRequests>())
            {
                result = repo.InsertOrUpdate(eventRequest);
            }


            return RedirectToAction("Index","Events");
        }

        
        public ActionResult Approve(Guid id)
        {
            using(var requestRepo = new Repository<EventRequests>())
            using (var eventRepo = new Repository<Event>())
            {
                var eventRequest = requestRepo.GetById(id);
                var _event = eventRepo.GetById(eventRequest.EventId);
                _event.Name = eventRequest.RequestName;
                _event.OrganizerName = eventRequest.RequestOrganizer;
                _event.State = eventRequest.RequestState;
                _event.UserId = eventRequest.OrganizerId.ToString();
                _event.ZipCode = eventRequest.RequestZipCode;
                _event.Address1 = eventRequest.RequestAddress1;
                _event.Address2 = eventRequest.RequestAddress2;
                _event.City = eventRequest.RequestCity;
                _event.Country = eventRequest.RequestCountry;
                _event.EntryFee = eventRequest.RequestEntryFee;
                _event.EventDateTime = eventRequest.RequestEventDateTime;

                eventRepo.InsertOrUpdate(_event);

                eventRequest.IsApproved = true;
                eventRequest.IsUpdated = true;
                eventRequest.ProcessedDate = DateTime.Now;
                eventRequest.ProcessedUserId = new Guid(User.Identity.GetUserId());

                requestRepo.InsertOrUpdate(eventRequest);

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(Guid id)
        {
            using (var repo = new Repository<EventRequests>())
            {
                var eventRequest = repo.GetById(id);

                repo.Remove(eventRequest);

                return RedirectToAction("Organizer", "Home");
            }
        }

        

        public ActionResult Detail(Guid id)
        {
            using (var repo = new Repository<EventRequests>())
            {
                var eventRequest = repo.GetById(id);
                var model = Mapper.Map<EventRequests, EventRequestDetailViewModel>(eventRequest);
                return View(model);
            }            
        }

    }
}