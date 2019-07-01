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
    public class WorksController : Controller
    {
        CompanyDB db = new CompanyDB();
        // GET: Admin/Works
        public ActionResult Index()
        {
            Covers covers = db.Covers.FirstOrDefault(c => c.Page == "Works");
            string cover = "";
            if (covers != null)
            {
                cover = db.Covers.FirstOrDefault(c => c.Page == "Works").Photo;
            }
            else
            {
                cover = null;
            }

            WorksViewModel model = new WorksViewModel()
            {
                Portfolio = new Portfolio(),
                Portfolios = db.Portfolio.ToList(),
                Cover = cover,
                Header = "Create new Portfolio",
                Action = "Create"
            };
            return View(model);
        }

        // POST: Admin/Works/Create
        [HttpPost]
        public ActionResult Create(Portfolio Portfolio, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHssmmffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/SiteImages/") + fileName);
                    Portfolio.Photo = fileName;
                }
                
                db.Portfolio.Add(Portfolio);
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
            var portfolio = db.Portfolio.FirstOrDefault(p => p.id == id);

            if (portfolio != null)
            {
                WorksViewModel model = new WorksViewModel()
                {
                    Portfolio = portfolio,
                    Portfolios = db.Portfolio.ToList(),
                    Cover = db.Covers.FirstOrDefault(c => c.Page == "Works").Photo,
                    Header = "Edit Portfolio",
                    Action = "Edit"
                };
                return View("Index",model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //POST: Admin/Works/Edit/5
        [HttpPost]
        public ActionResult Edit(Portfolio Portfolio, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if(file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHssmmffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/SiteImages/") + fileName);
                    Portfolio.Photo = fileName;
                    db.Entry(Portfolio).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(Portfolio).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(Portfolio).Property(p => p.Photo).IsModified = false;
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
            var portfolio = db.Portfolio.FirstOrDefault(p => p.id == id);

            if (portfolio != null)
            {
                db.Portfolio.Remove(portfolio);
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
            if(file != null)
            {
               string fileName = DateTime.Now.ToString("yyyyMMddHHssmmffff") + file.FileName;
                file.SaveAs(Server.MapPath("~/Content/SiteImages/") + fileName);

                var cover =  db.Covers.FirstOrDefault(c => c.Page == "Works");

                if(cover != null)
                {
                    cover.Photo = fileName;
                    db.SaveChanges();
                }
                else
                {
                    db.Covers.Add(new Covers() { Photo = fileName, Page = "Works" });
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
