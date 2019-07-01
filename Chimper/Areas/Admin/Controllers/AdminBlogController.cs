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
    public class AdminBlogController : Controller
    {
        CompanyDB db = new CompanyDB();
        // GET: Admin/Works
        public ActionResult Index()
        {
            Covers covers = db.Covers.FirstOrDefault(c => c.Page == "Blog");
            string cover = "";
            if (covers != null)
            {
                cover = db.Covers.FirstOrDefault(c => c.Page == "Blog").Photo;
            }
            else
            {
                cover = null;
            }

            BlogViewModel model = new BlogViewModel()
            {
                Blog = new Blog(),
                Blogs = db.Blog.ToList(),
                Cover = cover,
                Header = "Create new Blog",
                Action = "Create"
            };
            return View(model);
        }

        // POST: Admin/Works/Create
        [HttpPost]
        public ActionResult Create(Blog Blog, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHssmmffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/SiteImages/") + fileName);
                    Blog.Photo = fileName;
                }

                Blog.ShareDate = DateTime.Now;
                db.Blog.Add(Blog);
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
            var blog = db.Blog.FirstOrDefault(p => p.id == id);

            Covers covers = db.Covers.FirstOrDefault(c => c.Page == "Blog");
            string cover = "";
            if (covers != null)
            {
                cover = db.Covers.FirstOrDefault(c => c.Page == "Blog").Photo;
            }
            else
            {
                cover = null;
            }

            if (blog != null)
            {
                BlogViewModel model = new BlogViewModel()
                {
                    Blog = blog,
                    Blogs = db.Blog.ToList(),
                    Cover = cover,
                    Header = "Edit Blog",
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
        public ActionResult Edit(Blog Blog, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string fileName = DateTime.Now.ToString("yyyyMMddHHssmmffff") + file.FileName;
                    file.SaveAs(Server.MapPath("~/Content/SiteImages/") + fileName);
                    Blog.Photo = fileName;
                    db.Entry(Blog).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(Blog).Property(p => p.ShareDate).IsModified = false;
                    db.SaveChanges();
                }
                else
                {
                    db.Entry(Blog).State = System.Data.Entity.EntityState.Modified;
                    db.Entry(Blog).Property(p => p.Photo).IsModified = false;
                    db.Entry(Blog).Property(p => p.ShareDate).IsModified = false;
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
            var blog = db.Blog.FirstOrDefault(p => p.id == id);

            if (blog != null)
            {
                db.Blog.Remove(blog);
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

                var cover = db.Covers.FirstOrDefault(c => c.Page == "Blog");

                if (cover != null)
                {
                    cover.Photo = fileName;
                    db.SaveChanges();
                }
                else
                {
                    db.Covers.Add(new Covers() { Photo = fileName, Page = "Blog" });
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
