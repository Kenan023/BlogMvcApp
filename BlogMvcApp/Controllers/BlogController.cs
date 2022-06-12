using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogMvcApp.Models;

namespace BlogMvcApp.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext db = new BlogContext();

        public ActionResult List(int? id,string q)
        {
            var bloglar = db.Bloglar
                 .Where(i => i.Onay == true)
                .Select(i => new BlogModel()
                {
                    Id = i.Id,
                    Basliq = i.Basliq.Length > 100 ? i.Basliq.Substring(0, 100) + "....." : i.Basliq,
                    Aciklama = i.Aciklama,
                    EklenmeTarihi = i.EklenmeTarihi,
                    IlkSeyfe = i.IlkSeyfe,
                    Onay = i.Onay,
                    Resm = i.Resm,
                    CategoryId=i.CategoryId
                }).AsQueryable();//asquerable o demekdir ki biz buna elave sorgularda yaza bilerik

            if (string.IsNullOrEmpty("q")==false)
            {
                bloglar = bloglar.Where(i => i.Basliq.Contains(q) || i.Aciklama.Contains(q));
            }

            if (id!=null)
            {
                bloglar = bloglar.Where(i => i.CategoryId == id);
            }
            return View(bloglar.ToList());
        }

        // GET: Blog
        public ActionResult Index()
        {
            var bloglar = db.Bloglar.Include(b => b.Category).OrderByDescending(i => i.EklenmeTarihi);
            return View(bloglar.ToList());
        }

        // GET: Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Basliq,Aciklama,Resm,Icerik,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.EklenmeTarihi = DateTime.Now;
                db.Bloglar.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Basliq,Aciklama,Resm,Icerik,Onay,IlkSeyfe,CategoryId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                var entity = db.Bloglar.Find(blog.Id);
                if (entity!=null)
                {
                    entity.Basliq = blog.Basliq;
                    entity.Aciklama = blog.Aciklama;
                    entity.Resm = blog.Resm;
                    entity.Icerik = blog.Icerik;
                    entity.Onay = blog.Onay;
                    entity.IlkSeyfe = blog.IlkSeyfe;
                    entity.CategoryId = blog.CategoryId;

                    TempData["Blog"] = entity;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            ViewBag.CategoryId = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryId);
            return View(blog);
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Bloglar.Find(id);
            db.Bloglar.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
