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
    public class MovieBookingOpenController : Controller
    {
        // GET: MovieBookings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Guid movieId)
        {
            using (var repo = new Repository<BookingOpenMovie>())
            {
                var bookingMovie = new BookingOpenMovie
                {
                    MovieId = movieId
                };

                bookingMovie = repo.InsertOrUpdate(bookingMovie);

                return RedirectToAction("Detail", "Movies", new { id = movieId, message = "Movie opened for bookings" });
            }
        }

        public ActionResult Delete(Guid movieId)
        {
            using (var preRepo = new Repository<PreBookingMovie>())
            using (var repo = new Repository<BookingOpenMovie>())
            {
                var bookingMovie = repo.GetAll;
                var preBookingMovie = preRepo.GetAll;

                preRepo.RemoveAll(preBookingMovie.Where(x => x.MovieId == movieId));
                repo.RemoveAll(bookingMovie.Where(x => x.MovieId == movieId));

                return RedirectToAction("Detail", "Movies", new { id = movieId, message = "Movie bookings are closed" });
            }
        }
    }

    [Authorize]
    public class MoviePreBokingOpenController : Controller
    {
        // GET: MoviePreBokings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Guid movieId)
        {
            using (var repo = new Repository<PreBookingMovie>())
            {
                var preBookingMovie = new PreBookingMovie
                {
                    MovieId = movieId
                };

                preBookingMovie = repo.InsertOrUpdate(preBookingMovie);

                return RedirectToAction("Create", "MovieBookingOpen", new { movieId = movieId });
            }
        }

        public ActionResult Delete(Guid movieId)
        {
            using (var repo = new Repository<BookingOpenMovie>())
            using (var preRepo = new Repository<PreBookingMovie>())
            {
                var preBookingMovie = preRepo.GetAll;
                var bookingMovie = repo.GetAll;

                repo.RemoveAll(bookingMovie.Where(x => x.MovieId == movieId));
                preRepo.RemoveAll(preBookingMovie.Where(x => x.MovieId == movieId));

                return RedirectToAction("Detail", "Movies", new { id = movieId, message = "Movie bookings are closed" });
            }
        }
    }
}