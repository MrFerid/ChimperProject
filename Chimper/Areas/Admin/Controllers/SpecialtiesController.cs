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
    public class SpecialtiesController : Controller
    {
        CompanyDB db = new CompanyDB();
        // GET: Admin/Works
        public ActionResult Index()
        {
            Covers special = db.Covers.FirstOrDefault(c => c.Page == "Specialties");
            string cover = "";
            if (special != null)
            {
                cover = db.Covers.FirstOrDefault(c => c.Page == "Specialties").Photo;
            }
            else
            {
                cover = null;
            }
            var model = new SpecViewModel()
            {
                Cover = cover,
                Specialy = new Specialties(),
                Specialties = db.Specialties.ToList(),
                Header = "Yeni ixtisas elave edin",
                Action = "Create"
            };

            return View(model);
        }

        // POST: Admin/Works/Create
        [HttpPost]
        public ActionResult Create(Specialties Specialy)
        {
            if (ModelState.IsValid)
            {
                db.Specialties.Add(Specialy);
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
            var speciality = db.Specialties.FirstOrDefault(p => p.id == id);

            if (speciality != null)
            {
                Covers specCover = db.Covers.FirstOrDefault(c => c.Page == "Specialties");
                string cover = "";
                if (specCover != null)
                {
                    cover = db.Covers.FirstOrDefault(c => c.Page == "Specialties").Photo;
                }
                else
                {
                    cover = null;
                }

                var model = new SpecViewModel()
                {
                    Specialy = db.Specialties.FirstOrDefault(s => s.id == id),
                    Specialties = db.Specialties.ToList(),
                    Cover = cover,
                    Header = "Edit Specialty",
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
        public ActionResult Edit(Specialties Specialties)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Specialties).State = System.Data.Entity.EntityState.Modified;
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
            var specialty = db.Specialties.FirstOrDefault(p => p.id == id);

            if (specialty != null)
            {
                db.Specialties.Remove(specialty);
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

                var cover = db.Covers.FirstOrDefault(c => c.Page == "Specialties");

                if (cover != null)
                {
                    cover.Photo = fileName;
                    db.SaveChanges();
                }
                else
                {
                    db.Covers.Add(new Covers() { Photo = fileName, Page = "Specialties" });
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