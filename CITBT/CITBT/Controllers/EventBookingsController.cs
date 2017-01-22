using CITBT.Models.DbModels;
using CITBT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CITBT.Controllers
{
    [Authorize]
    public class EventBookingOpenController : Controller
    {
        // GET: EventBookings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Guid eventId)
        {
            using (var repo = new Repository<BookingOpenEvent>())
            {
                var bookingEvent = new BookingOpenEvent
                {
                    EventId = eventId
                };

                bookingEvent = repo.InsertOrUpdate(bookingEvent);

                return RedirectToAction("Detail", "Events", new { id = eventId , message = "Event opened for bookings"});
            }
        }

        public ActionResult Delete(Guid eventId)
        {
            using (var preRepo = new Repository<PreBookingEvent>())
            using (var repo = new Repository<BookingOpenEvent>())
            {
                var bookingEvent = repo.GetAll;
                var preBooking = preRepo.GetAll;

                repo.RemoveAll(bookingEvent.Where(x=>x.EventId == eventId));
                preRepo.RemoveAll(preBooking.Where(x => x.EventId == eventId));

                return RedirectToAction("Detail", "Events", new { id = eventId , message = "Event closed for booking" });
            }
        }
    }

    [Authorize]
    public class EventPreBookingOpenController : Controller
    {
        // GET: EventPreBookings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Guid eventId)
        {
            using (var repo = new Repository<PreBookingEvent>())
            {
                var preBookingEvent = new PreBookingEvent
                {
                    EventId = eventId
                };

                preBookingEvent = repo.InsertOrUpdate(preBookingEvent);

                return RedirectToAction("Create", "EventBookingOpen", new { eventId = eventId });
            }
        }

        public ActionResult Delete(Guid eventId)
        {
            using (var repo = new Repository<BookingOpenEvent>())
            using (var preRepo = new Repository<PreBookingEvent>())
            {
                var preBookingEvent = preRepo.GetAll;
                var bookingEvent = repo.GetAll;

                repo.RemoveAll(bookingEvent.Where(x => x.EventId == eventId));
                preRepo.RemoveAll(preBookingEvent.Where(x=>x.EventId == eventId));

                return RedirectToAction("Detail", "Events", new { id = eventId, message = "Event closed for pre booking" });
            }
        }
    }
}