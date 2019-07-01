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
    public class TestController : Controller
    {
        CompanyDB db = new CompanyDB();
        // GET: Admin/Works
        public ActionResult Index()
        {
           
            TestViewModel model = new TestViewModel()
            {
                Test = new Testimonials(),
                Tests = db.Testimonials.ToList(),
                Header = "Create new Testimonial",
                Action = "Create"
            };
            return View(model);
        }

        // POST: Admin/Works/Create
        [HttpPost]
        public ActionResult Create(Testimonials Test, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHssmmffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/SiteImages/") + fileName);
                    Test.Photo = fileName;
                }

                db.Testimonials.Add(Test);
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
            var test = db.Testimonials.FirstOrDefault(p => p.id == id);

            if (test != null)
            {
                TestViewModel model = new TestViewModel()
                {
                    Test = test,
                    Tests = db.Testimonials.ToList(),
                    Header = "Edit Testmonial",
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
        public ActionResult Edit(Testimonials Test, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHssmmffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/SiteImages/") + fileName);
                    Test.Photo = fileName;
                    db.Entry(Test).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(Test).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(Test).Property(p => p.Photo).IsModified = false;
                    db.SaveChanges();
                }

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
            var test = db.Testimonials.FirstOrDefault(p => p.id == id);

            if (test != null)
            {
                db.Testimonials.Remove(test);
                db.SaveChanges();
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

    }
}
