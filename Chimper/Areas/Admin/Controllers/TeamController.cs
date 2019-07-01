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
    public class TeamController : Controller
    {
        CompanyDB db = new CompanyDB();
        // GET: Admin/Works
        public ActionResult Index()
        {
            Covers covers = db.Covers.FirstOrDefault(c => c.Page == "About");
            string cover = "";
            if (covers != null)
            {
                cover = db.Covers.FirstOrDefault(c => c.Page == "About").Photo;
            }
            else
            {
                cover = null;
            }

            TeamViewModel model = new TeamViewModel()
            {
                Team = new Team(),
                Teams = db.Team.ToList(),
                Cover = cover,
                Header = "Create new Team member",
                Action = "Create"
            };
            return View(model);
        }

        // POST: Admin/Works/Create
        [HttpPost]
        public ActionResult Create(Team Team, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHssmmffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/SiteImages/") + fileName);
                    Team.Photo = fileName;
                }

                db.Team.Add(Team);
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
            var team = db.Team.FirstOrDefault(p => p.id == id);

            Covers covers = db.Covers.FirstOrDefault(c => c.Page == "About");
            string cover = "";
            if (covers != null)
            {
                cover = db.Covers.FirstOrDefault(c => c.Page == "About").Photo;
            }
            else
            {
                cover = null;
            }

            if (team != null)
            {
                TeamViewModel model = new TeamViewModel()
                {
                    Team = team,
                    Teams = db.Team.ToList(),
                    Cover = cover,
                    Header = "Edit Team member",
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
        public ActionResult Edit(Team Team, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHssmmffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/SiteImages/") + fileName);
                    Team.Photo = fileName;
                    db.Entry(Team).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(Team).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(Team).Property(p => p.Photo).IsModified = false;
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
            var team = db.Team.FirstOrDefault(p => p.id == id);

            if (team != null)
            {
                db.Team.Remove(team);
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

                var cover = db.Covers.FirstOrDefault(c => c.Page == "About");

                if (cover != null)
                {
                    cover.Photo = fileName;
                    db.SaveChanges();
                }
                else
                {
                    db.Covers.Add(new Covers() { Photo = fileName, Page = "About" });
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
