using Chimper.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chimper.Controllers
{
    public class ContactController : Controller
    {
        CompanyDB db = new CompanyDB();
        // GET: Contact
        public ActionResult Index()
        {
            var model = db.Company.FirstOrDefault();
            ViewBag.Photo = db.Covers.FirstOrDefault(c => c.Page == "Contact").Photo;
            return View(model);
        }
    }
}