using Chimper.Areas.ViewModel;
using Chimper.DAL;
using Chimper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chimper.Areas.Admin.Controllers
{
    public class CompanyController : Controller
    {
        CompanyDB db = new CompanyDB();
        // GET: Admin/Works
        public ActionResult Index()
        {
            Covers covers = db.Covers.FirstOrDefault(c => c.Page == "Contact");
            Company comp = db.Company.FirstOrDefault();
            string cover = "";
            string action = "";
            Company company;

            if (covers != null) { cover = db.Covers.FirstOrDefault(c => c.Page == "Contact").Photo;  }
            else{ cover = null; }

            if(comp == null) { action = "Create"; company = new Company();  }
            else { action = "Edit"; company = comp; }

            CompanyViewModel model = new CompanyViewModel()
            {
                Company = company,
                Cover = cover,
                Action = action
            };
            return View(model);
        }

        // POST: Admin/Works/Create
        [HttpPost]
        public ActionResult Create(Company Company)
        {
            if (ModelState.IsValid)
            {

                db.Company.Add(Company);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //POST: Admin/Works/Edit/5
        [HttpPost]
        public ActionResult Edit(Company Company)
        {
            if (ModelState.IsValid)
            {
                    db.Entry(Company).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public JsonResult Photo(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHssmmffff") + file.FileName;
                file.SaveAs(Server.MapPath("~/Content/SiteImages/") + fileName);

                var cover = db.Covers.FirstOrDefault(c => c.Page == "Contact");

                if (cover != null)
                {
                    cover.Photo = fileName;
                    db.SaveChanges();
                }
                else
                {
                    db.Covers.Add(new Covers() { Photo = fileName, Page = "Contact" });
                    db.SaveChanges();
                }

                return Json(fileName);
            }
            else
            {
                return Json(new { success = false });
            }

        }
    }
}
