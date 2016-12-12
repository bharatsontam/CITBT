using CITBT.Models;
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
using CITBT.ViewModels.Theaters;
using CITBT.ViewModels.Theaters.TheaterShowTimings;

namespace CITBT.Controllers
{
    [Authorize]
    public class TheatresController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public TheatresController()
        {

        }
        public TheatresController(ApplicationUserManager userManager, ApplicationDbContext context)
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
        // GET: Theatres
        public ActionResult Index()
        {
            using (var theaterRepo = new Repository<Theater>())
            {
                var theatres = theaterRepo.GetAll;
                var model = Mapper.Map<IEnumerable<Theater>, IEnumerable<TheaterViewModel>>(theatres);
                return View(model);
            }
        }

        public ActionResult Create()
        {
            var model = new CreateTheaterViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateTheaterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var theater = Mapper.Map<CreateTheaterViewModel, Theater>(model);

            var result = new Theater();
            using (var theaterRepo = new Repository<Theater>())
            {
                result = theaterRepo.InsertOrUpdate(theater);
            }
            return RedirectToAction("Detail", new { id = result.Id });
        }

        public ActionResult Edit(Guid id)
        {
            using (var theaterRepo = new Repository<Theater>())
            {
                var theater = theaterRepo.GetById(id);
                var model = Mapper.Map<Theater, EditTheaterViewModel>(theater);

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(EditTheaterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var theater = Mapper.Map<EditTheaterViewModel, Theater>(model);

            var result = new Theater();
            using (var theaterRepo = new Repository<Theater>())
            {
                result = theaterRepo.InsertOrUpdate(theater);
            }
            return RedirectToAction("Detail", new { id = result.Id });
        }

        public ActionResult Detail(Guid id)
        {
            using (var theaterRepo = new Repository<Theater>())
            {
                var theater = theaterRepo.GetById(id);

                var model = Mapper.Map<Theater, TheatreDetailViewModel>(theater);
                using (var repo = new Repository<TheatreShowTimings>())
                {
                    model.TheatreShowTimings = repo.GetAll.Where(x => x.TheatreId == model.Id);
                }
                return View(model);
            }
        }

        public ActionResult Delete(Guid id)
        {
            using (var repo = new Repository<Theater>())
            {
                var theater = repo.GetById(id);
                repo.Remove(theater);
                return RedirectToAction("Index");
            }
        }
    }

    [Authorize]
    public class TheaterShowTimesController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public TheaterShowTimesController()
        {

        }
        public TheaterShowTimesController(ApplicationUserManager userManager, ApplicationDbContext context)
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
            using (var repo = new Repository<TheatreShowTimings>())
            {
                var theaterShowTimings = repo.GetAll;
                var model = Mapper.Map<IEnumerable<TheatreShowTimings>, IEnumerable<TheatreShowTimingsViewModel>>(theaterShowTimings);
                return View(model);
            }
        }

        public ActionResult Create(Guid theaterId)
        {
            var model = new CreateTheaterShowTimeViewModel();
            model.TheatreId = theaterId;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateTheaterShowTimeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var theaterShowtime = Mapper.Map<CreateTheaterShowTimeViewModel, TheatreShowTimings>(model);

            var result = new TheatreShowTimings();

            using (var repo = new Repository<TheatreShowTimings>())
            {
                result = repo.InsertOrUpdate(theaterShowtime);
            }
            return RedirectToAction("Detail", "Theatres", new { id = result.TheatreId });
        }

        public ActionResult Edit(Guid id)
        {
            using (var repo = new Repository<TheatreShowTimings>())
            {
                var theaterShowtime = repo.GetById(id);
                var model = Mapper.Map<TheatreShowTimings, EditTheaterShowTImeViewModel>(theaterShowtime);
                return View(model);
            }
            
        }

        [HttpPost]
        public ActionResult Edit(EditTheaterShowTImeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var theaterShowtime = Mapper.Map<EditTheaterShowTImeViewModel, TheatreShowTimings>(model);

            var result = new TheatreShowTimings();

            using (var repo = new Repository<TheatreShowTimings>())
            {
                result = repo.InsertOrUpdate(theaterShowtime);
            }
            return RedirectToAction("Detail", "Theatres", new { id = result.TheatreId });
        }
        
        public ActionResult Delete(Guid id)
        {
            using (var repo = new Repository<TheatreShowTimings>())
            {
                var theaterShowtime = repo.GetById(id);

                repo.Remove(theaterShowtime);

                return RedirectToAction("Detail", "Theatres", new { id = theaterShowtime.TheatreId });
            }
        }
    }
}