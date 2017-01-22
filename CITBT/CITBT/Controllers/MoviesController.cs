using CITBT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using CITBT.Repository;
using CITBT.Models.DbModels;
using AutoMapper;
using CITBT.ViewModels.Movies;
using CITBT.ViewModels.Movies.MovieShowTimes;
using CITBT.ViewModels.Theaters;
using CITBT.ViewModels;
using CITBT.ViewModels.Purchase;

namespace CITBT.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public MoviesController()
        {

        }
        public MoviesController(ApplicationUserManager userManager, ApplicationDbContext context)
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
        // GET: Movies
        public ActionResult Index()
        {
            using (var repo = new Repository<Movie>())
            {
                var movies = repo.GetAll;
                var model = Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieViewModel>>(movies);
                return View(model);
            }
        }

        public ActionResult Create()
        {
            var model = new CreateMovieViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateMovieViewModel model, HttpPostedFileBase imagefile = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var movie = Mapper.Map<CreateMovieViewModel, Movie>(model);
            if (imagefile != null)
            {
                movie.FileName = imagefile.FileName;
                movie.ContentType = imagefile.ContentType;
                //movie.Image
                movie.Image = new byte[imagefile.ContentLength];
                imagefile.InputStream.Read(movie.Image, 0, imagefile.ContentLength);
            }
            var result = new Movie();
            using (var repo = new Repository<Movie>())
            {
                result = repo.InsertOrUpdate(movie);
            }

            return RedirectToAction("Detail", new { id = result.Id });
        }

        public ActionResult Edit(Guid id)
        {
            using (var repo = new Repository<Movie>())
            {
                var movie = repo.GetById(id);
                var model = Mapper.Map<Movie, EditMovieModel>(movie);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(EditMovieModel model, HttpPostedFileBase imagefile)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var movie = Mapper.Map<EditMovieModel, Movie>(model);

            var result = new Movie();
            using (var movieRepo = new Repository<Movie>())
            using (var repo = new Repository<Movie>())
            {
                if (imagefile != null)
                {
                    movie.FileName = imagefile.FileName;
                    movie.ContentType = imagefile.ContentType;
                    //movie.Image
                    movie.Image = new byte[imagefile.ContentLength];
                    imagefile.InputStream.Read(movie.Image, 0, imagefile.ContentLength);
                }
                else
                {
                    var _movie = movieRepo.GetById(model.Id);
                    movie.FileName = _movie.FileName;
                    movie.ContentType = _movie.ContentType;
                    movie.Image = _movie.Image;
                }
                result = repo.InsertOrUpdate(movie);
            }

            return RedirectToAction("Detail", new { id = result.Id });
        }

        public ActionResult Detail(Guid id , string message = null)
        {
            ViewBag.Message = null;
            using (var repo = new Repository<Movie>())
            {
                var movie = repo.GetById(id);
                var model = Mapper.Map<Movie, MovieDetailViewModel>(movie);
                model.MovieShowTimes = Mapper.Map<IEnumerable<MovieShowTimes>, IEnumerable<MovieShowTimesDetailViewModel>>(movie.MovieShowTimes);

                ViewBag.BookingOpened = movie.BookingOpenMovies.Count > 0;
                ViewBag.PreBookingOpened = movie.PreBookingMovies.Count > 0;

                return View(model);
            }
        }

        public ActionResult Delete(Guid id)
        {
            using (var repo = new Repository<Movie>())
            {
                var movie = repo.GetById(id);

                repo.Remove(movie);

                return RedirectToAction("Index");
            }
        }
    }
    [Authorize]
    public class MovieShowTimeController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public MovieShowTimeController()
        {

        }
        public MovieShowTimeController(ApplicationUserManager userManager, ApplicationDbContext context)
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

        public ActionResult Index()
        {
            using (var repo = new Repository<MovieShowTimes>())
            {
                var movieShowTimes = repo.GetAll;

                var model = Mapper.Map<IEnumerable<MovieShowTimes>, IEnumerable<MovieShowTimesViewModel>>(movieShowTimes);

                return View(model);
            }

        }

        public ActionResult Create(Guid movieId)
        {
            var model = new CreateMovieShowTimesViewModel();
            model.MovieId = movieId;
            using (var repo = new Repository<Theater>())
            {
                var theaters = repo.GetAll;
                model.Theaters = theaters.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateMovieShowTimesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var movieShowTimes = Mapper.Map<CreateMovieShowTimesViewModel, MovieShowTimes>(model);
            var result = new MovieShowTimes();
            using (var repo = new Repository<MovieShowTimes>())
            {
                result = repo.InsertOrUpdate(movieShowTimes);
            }
            return RedirectToAction("Detail", "Movies", new { id = result.MovieId });
        }

        public ActionResult Edit(Guid id)
        {
            using (var theaterRepo = new Repository<Theater>())
            using (var repo = new Repository<MovieShowTimes>())
            {
                var movieShowtimes = repo.GetById(id);
                var model = Mapper.Map<MovieShowTimes, EditMovieShowTimesViewModel>(movieShowtimes);

                var theaters = theaterRepo.GetAll;

                model.Theaters = theaters.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

                return View(model);
            }

        }

        [HttpPost]
        public ActionResult Edit(EditMovieShowTimesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var movieShowTimes = Mapper.Map<EditMovieShowTimesViewModel, MovieShowTimes>(model);
            var result = new MovieShowTimes();
            using (var repo = new Repository<MovieShowTimes>())
            {
                result = repo.InsertOrUpdate(movieShowTimes);
            }
            return RedirectToAction("Detail", "Movies", new { id = result.MovieId });
        }

        public ActionResult Delete(Guid id)
        {
            using (var repo = new Repository<MovieShowTimes>())
            {
                var movieShowTimes = repo.GetById(id);
                repo.Remove(movieShowTimes);

                return RedirectToAction("Detail", "Movies", new { id = movieShowTimes.MovieId });
            }
        }

    }
    [Authorize]
    public class BookingMovieController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public BookingMovieController()
        {

        }
        public BookingMovieController(ApplicationUserManager userManager, ApplicationDbContext context)
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


        public ActionResult Create(Guid movieId)
        {
            var model = new CreatePurchasedMovieViewModel();
            model.UserId = User.Identity.GetUserId();
            model.MovieId = movieId;

            using(var movieRepo = new Repository<Movie>())
            using (var repo = new Repository<MovieShowTimes>())
            {
                var movieShowTimes = repo.GetAll;

                model.MovieShowTimeList = movieShowTimes.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Theatre.Name + " " + x.ShowTime });

                var movie = movieRepo.GetById(model.MovieId);

                model.MovieName = movie.MovieName;
                model.MovieTicketPrice = movie.TicketPrice;
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreatePurchasedMovieViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = Mapper.Map<CreatePurchasedMovieViewModel, UserPurchasedMovies>(model);


            using (var repo = new Repository<UserPurchasedMovies>())
            {
                result = repo.InsertOrUpdate(result);
            }

            return RedirectToAction("Detail", new { id = result.Id });
        }

        public ActionResult Detail(Guid id)
        {
            using (var repo = new Repository<UserPurchasedMovies>())
            {
                var result = repo.GetById(id);

                var model = Mapper.Map<UserPurchasedMovies, PurchasedMoviesViewModel>(result);
                var user = UserManager.Users.Where(x => x.Id == result.User.UserId.ToString()).FirstOrDefault();
                ViewBag.UserName = user.FirstName + " " + user.LastName;
                return View(result);
            }
        }

        [Authorize]
        public ActionResult Delete(Guid id)
        {
            using (var cancelRepo = new Repository<UserMovieCancellationRequests>())
            using (var repo = new Repository<UserPurchasedMovies>())
            {
                var result = repo.GetById(id);

                result.IsCancelled = true;
                result.IsRefunded = false;

                result = repo.InsertOrUpdate(result);

                var cancelRequest = new UserMovieCancellationRequests
                {
                    IsApproved = false,
                    IsRefunded = false,
                    MovieId = result.MovieId,
                    RequestDate = DateTime.Now,
                    UserMoviePurchaseId = result.Id,
                    UserId = result.UserId
                };

                var canceResult = cancelRepo.InsertOrUpdate(cancelRequest);

                return RedirectToAction("UserHome", "Home");
            }
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Approve(Guid id)
        {
            using (var cancelRepo = new Repository<UserMovieCancellationRequests>())
            using (var repo = new Repository<UserPurchasedMovies>())
            {
                var cancelRequest = cancelRepo.GetById(id);

                var movieRequest = repo.GetById(cancelRequest.UserMoviePurchaseId);

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
    public class MovieCancellationsController : Controller
    {
        
        public ActionResult Index()
        {
            using (var repo = new Repository<UserMovieCancellationRequests>())
            {
                var model = repo.GetAll;
                return View(model);
            }
        }
    }
}