using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using NerdDinner.Models;
using NerdDinner.ViewModels;
namespace NerdDinner.Controllers
{
    public class DinnersController : Controller
    {
        private ApplicationDbContext _context;

        public DinnersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize]
        public ActionResult New()
        {
            var countries = _context.Countries.ToList();
            var viewModel = new DinnerFormViewModel
            {
                Countries = countries
            };

            return View("DinnerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Save(Dinner dinner)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DinnerFormViewModel
                {
                    Dinner = dinner,
                    Countries = _context.Countries.ToList()
                };

                return View("DinnerForm", viewModel);
            }

            if (dinner.Id == 0) 
            {
                dinner.Host = dinner.returnUsername(User.Identity.GetUserName());
                _context.Dinners.Add(dinner);
            }
            else
            {
                var dinnerInDb = _context.Dinners.Single(d => d.Id == dinner.Id);

                dinnerInDb.Title = dinner.Title;
                dinnerInDb.EventDate = dinner.EventDate;
                dinnerInDb.Description = dinner.Description;
                dinnerInDb.Address = dinner.Address;
                dinnerInDb.CountryId = dinner.CountryId;
                dinnerInDb.Phone = dinner.Phone;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Dinners");
        }

        public ViewResult Index()
        {
            var dinners = _context.Dinners.Include(d => d.Country).ToList();

            return View(dinners);
        }

        public ActionResult Details(int id)
        {
            var dinner = _context.Dinners.Include(d => d.Country).SingleOrDefault(c => c.Id == id);

            if (dinner == null)
                return HttpNotFound();

            return View(dinner);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var dinner = _context.Dinners.SingleOrDefault(d => d.Id == id);

            if (dinner == null)
            {
                return HttpNotFound();
            }

            var viewModel = new DinnerFormViewModel
            {
                Dinner = dinner,
                Countries = _context.Countries.ToList()
            };

            return View("DinnerForm", viewModel);
        }
    }
}