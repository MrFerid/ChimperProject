using Chimper.Areas.ViewModel;
using Chimper.DAL;
using Chimper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chimper.Controllers
{
    public class ServicesController : Controller
    {
        CompanyDB db = new CompanyDB();
        // GET: Services
        public ActionResult Index()
        {
            ServicesViewModel model = new ServicesViewModel()
            {
                Service = db.Service.ToList(),
                Testimonials = db.Testimonials.ToList(),
                Cover = db.Covers.FirstOrDefault(c => c.Page == "Service").Photo
            };

            return View(model);
        }
    }
}