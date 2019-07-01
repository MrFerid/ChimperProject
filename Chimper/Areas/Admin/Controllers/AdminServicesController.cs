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
    public class AdminServicesController : Controller
    {

        CompanyDB db = new CompanyDB();
        // GET: Admin/Works
        public ActionResult Index()
        {
            Covers portFolio = db.Covers.FirstOrDefault(c => c.Page == "Service");
            string cover = "";
            if (portFolio != null)
            {
                cover = db.Covers.FirstOrDefault(c => c.Page == "Service").Photo;
            }
            else
            {
                cover = null;
            }
            var model = new ServiceViewModel()
            {
                Cover = cover,
                Service = new Service(),
                Services = db.Service.ToList(),
                Header = "Yeni servis elave edin",
                Action = "Create"
            };

            return View(model);
        }

        // POST: Admin/Works/Create
        [HttpPost]
        public ActionResult Create(Service Service)
        {
            if (ModelState.IsValid)
            {
                db.Service.Add(Service);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Works/Edit/5
        public ActionResult Edit(int id)
        {
            var service = db.Service.FirstOrDefault(p => p.id == id);

            if (service != null)
            {
                Covers portFolio = db.Covers.FirstOrDefault(c => c.Page == "Service");
                string cover = "";
                if (portFolio != null)
                {
                    cover = db.Covers.FirstOrDefault(c => c.Page == "Service").Photo;
                }
                else
                {
                    cover = null;
                }

                var model = new ServiceViewModel()
                {
                    Service = db.Service.FirstOrDefault(s => s.id == id),
                    Services = db.Service.ToList(),
                    Cover = cover,
                    Header = "Edit Service",
                    Action = "Edit"
                };
               
                return View("Index", model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //POST: Admin/Works/Edit/5
        [HttpPost]
        public ActionResult Edit(Service Service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Service).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Admin/Works/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var service = db.Service.FirstOrDefault(p => p.id == id);

            if (service != null)
            {
                db.Service.Remove(service);
                db.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public JsonResult Photo(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHssmmffff") + file.FileName;
                file.SaveAs(Server.MapPath("~/Content/SiteImages/") + fileName);

                var cover = db.Covers.FirstOrDefault(c => c.Page == "Service");

                if (cover != null)
                {
                    cover.Photo = fileName;
                    db.SaveChanges();
                }
                else
                {
                    db.Covers.Add(new Covers() { Photo = fileName, Page = "Service" });
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