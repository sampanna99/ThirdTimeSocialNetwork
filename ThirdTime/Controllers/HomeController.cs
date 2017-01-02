﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ThirdTime.Models;
using ThirdTime.ViewModels;

namespace ThirdTime.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs.Include(a => a.Artist).Include(g => g.Genre).Where(g => g.DateTime > DateTime.Now);
            var viewModel = new HomeViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs"
            };

            return View("Gigs", viewModel);
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
    }
}