using AutoMapper;
using CITBT.Models;
using CITBT.Models.DbModels;
using CITBT.Repository;
using CITBT.ViewModels.Offers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
namespace CITBT.Controllers
{
    [Authorize]
    public class OffersController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public OffersController()
        {

        }
        public OffersController(ApplicationUserManager userManager, ApplicationDbContext context)
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
        // GET: Offers
        public ActionResult Index()
        {
            using (var repo = new Repository<Offer>())
            {
                var offers = repo.GetAll;
                var model = Mapper.Map<IEnumerable<Offer>, IEnumerable<OfferViewModel>>(offers);
                return View(model);
            }
        }

        public ActionResult Create()
        {
            var model = new CreateOfferViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateOfferViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var offer = Mapper.Map<CreateOfferViewModel, Offer>(model);
            using (var repo = new Repository<Offer>())
            {
                offer = repo.InsertOrUpdate(offer);
            }

            return RedirectToAction("Detail", new { id = offer.Id });
        }

        public ActionResult Edit(Guid id)
        {
            using (var repo = new Repository<Offer>())
            {
                var offer = repo.GetById(id);
                var model = Mapper.Map<Offer, EditOfferViewModel>(offer);
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(EditOfferViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var offer = Mapper.Map<EditOfferViewModel, Offer>(model);
            using (var repo = new Repository<Offer>())
            {
                offer = repo.InsertOrUpdate(offer);
            }

            return RedirectToAction("Detail", new { id = offer.Id });
        }

        public ActionResult Detail(Guid id)
        {
            using (var repo = new Repository<Offer>())
            {
                var offer = repo.GetById(id);
                var model = Mapper.Map<Offer, OfferDetailViewModel>(offer);
                model.UserApplicableToOffers.ForEach(x => { x.UserName = UserManager.Users.Where(y => y.Id == x.UserId).Select(z => z.FirstName + " " + z.LastName).FirstOrDefault(); });
                return View(model);
            }
        }

        public ActionResult Delete(Guid id)
        {
            using (var repo = new Repository<Offer>())
            {
                var offer = repo.GetById(id);
                repo.Remove(offer);
                return RedirectToAction("Index");
            }
        }

    }

    [Authorize]
    public class UserOffersController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _context;

        public UserOffersController()
        {

        }
        public UserOffersController(ApplicationUserManager userManager, ApplicationDbContext context)
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

        public ActionResult Create(Guid offerid)
        {
            var model = new CreateUserApplicableOffersViewModel();
            model.OfferId = offerid;
            var usersList = new List<SelectListItem>();
            UserManager.Users.ForEach(x =>
            {
                if (CheckUserRole.IsUserInRole(x.Id, "User"))
                {
                    usersList.Add(new SelectListItem { Text = x.FirstName + " " + x.LastName, Value = x.Id });
                }
            });
            model.UsersList = usersList;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CreateUserApplicableOffersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var offer = Mapper.Map<CreateUserApplicableOffersViewModel, UserApplicableToOffer>(model);

            using (var repo = new Repository<UserApplicableToOffer>())
            {
                offer = repo.InsertOrUpdate(offer);
            }

            return RedirectToAction("Detail", "Offers", new { id = offer.OfferId });
        }

        public ActionResult Edit(Guid id)
        {
            using (var repo = new Repository<UserApplicableToOffer>())
            {
                var offer = repo.GetById(id);
                var model = Mapper.Map<UserApplicableToOffer, EditUserApplicableOffersViewModel>(offer);
                var usersList = new List<SelectListItem>();
                UserManager.Users.ForEach(x =>
                {
                    if (CheckUserRole.IsUserInRole(x.Id, "User"))
                    {
                        usersList.Add(new SelectListItem { Text = x.FirstName + " " + x.LastName, Value = x.Id });
                    }
                });
                model.UsersList = usersList;

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(EditUserApplicableOffersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var offer = Mapper.Map<EditUserApplicableOffersViewModel, UserApplicableToOffer>(model);

            using (var repo = new Repository<UserApplicableToOffer>())
            {
                offer = repo.InsertOrUpdate(offer);
            }

            return RedirectToAction("Detail", "Offers", new { id = offer.OfferId });
        }

        public ActionResult Delete(Guid id)
        {
            using (var repo = new Repository<UserApplicableToOffer>())
            {
                var offer = repo.GetById(id);

                repo.Remove(offer);

                return RedirectToAction("Detail", "Offers", new { id = offer.OfferId });
            }
        }
    }
}