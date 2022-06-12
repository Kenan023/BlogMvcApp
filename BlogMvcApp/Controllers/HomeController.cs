using BlogMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMvcApp.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context = new BlogContext();
        public ActionResult Index()
        {
            var bloglar = context.Bloglar
                  .Where(i => i.Onay == true && i.IlkSeyfe == true)
                .Select(i => new BlogModel()
                {
                    Id = i.Id,
                    Basliq = i.Basliq.Length > 100 ? i.Basliq.Substring(0, 100) + "....." : i.Basliq,
                    Aciklama = i.Aciklama,
                    EklenmeTarihi = i.EklenmeTarihi,
                    IlkSeyfe = i.IlkSeyfe,
                    Onay = i.Onay,
                    Resm = i.Resm
                });
            return View(bloglar.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}