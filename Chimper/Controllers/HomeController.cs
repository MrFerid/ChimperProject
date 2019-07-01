using Chimper.DAL;
using Chimper.Models.ViewModel;
using Chimper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chimper.Controllers
{
    public class HomeController : Controller
    {
        CompanyDB db = new CompanyDB();
        public ActionResult Index()
        {
            IndexViewModel model = new IndexViewModel()
            {
                Company = db.Company.FirstOrDefault(),
                Blog = db.Blog.ToList(),
                Portfolio = db.Portfolio.ToList(),
                Service = db.Service.ToList(),
                Testimonials = db.Testimonials.ToList(),
                Cover = db.Covers.FirstOrDefault(c=> c.Page == "About").Photo
            };
            return View(model);
        }

        public ActionResult About()
        {
            AboutViewModel model = new AboutViewModel()
            {
                Company = db.Company.FirstOrDefault(),
                Specialties = db.Specialties.ToList(),
                Team = db.Team.ToList(),
                Testimonials = db.Testimonials.ToList(),
                Cover = db.Covers.ToList()
            };

            return View(model);
        }

        public ActionResult Work()
        {
            WorkViewModel model = new WorkViewModel()
            {
                Portfolio = db.Portfolio.ToList(),
                Testimonials = db.Testimonials.ToList(),
                Cover = db.Covers.FirstOrDefault(c => c.Page == "Works").Photo
            };

            return View(model);
        }
    }
}