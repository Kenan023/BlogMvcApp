using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext> //Eger Modelde deyisiklikler olsa Database silib tezeden yaradir
    {
        protected override void Seed(BlogContext context)
        {
            List<Category> kategoriler = new List<Category>()
            {
              new Category{KategoriAdi="C# "},
              new Category{KategoriAdi="Asp.Net MVC"},
              new Category{KategoriAdi="Asp.Net WebForm"},
              new Category{KategoriAdi="Windows Form"},
            };
            foreach (var item in kategoriler)
            {
                context.Kategoriler.Add(item);
            }
            context.SaveChanges();

            List<Blog> bloglar = new List<Blog>()
            {
                new Blog{Basliq="C# Delegate Haqqinda C# Delegate Haqqinda C# Delegate Haqqinda C# Delegate Haqqinda C# Delegate Haqqinda C# Delegate Haqqinda C# Delegate Haqqinda C# Delegate Haqqinda C# Delegate Haqqinda C# Delegate Haqqinda C# Delegate Haqqinda",Aciklama="C# Delegate HaqqindaC# Delegate Haqqinda",EklenmeTarihi=DateTime.Now.AddDays(-10),IlkSeyfe=true,Onay=true,Icerik="C# Delegate HaqqindaC# Delegate Haqqinda",Resm="1.jpg",CategoryId=1},
                new Blog{Basliq="C# Delegate ",Aciklama="C# Delegate HaqqindaC# Delegate Haqqinda",EklenmeTarihi=DateTime.Now.AddDays(-10),IlkSeyfe=true,Onay=false,Icerik="C# Delegate HaqqindaC# Delegate Haqqinda",Resm="1.jpg",CategoryId=1},
                new Blog{Basliq="C# Delegate Haqqinda",Aciklama="C# Delegate HaqqindaC# Delegate Haqqinda",EklenmeTarihi=DateTime.Now.AddDays(-30),IlkSeyfe=false,Onay=true,Icerik="C# Delegate HaqqindaC# Delegate Haqqinda",Resm="1.jpg",CategoryId=1},
                new Blog{Basliq="C# Delegate Haqqinda",Aciklama="C# Delegate HaqqindaC# Delegate Haqqinda",EklenmeTarihi=DateTime.Now.AddDays(-20),IlkSeyfe=true,Onay=true,Icerik="C# Delegate HaqqindaC# Delegate Haqqinda",Resm="2.jpg",CategoryId=2},
                new Blog{Basliq="C# Generic List Haqqinda",Aciklama="C# Delegate HaqqindaC# Delegate Haqqinda",EklenmeTarihi=DateTime.Now.AddDays(-5),IlkSeyfe=true,Onay=true,Icerik="C# Delegate HaqqindaC# Delegate Haqqinda",Resm="2.jpg",CategoryId=2},
                new Blog{Basliq="C# Delegate Haqqinda",Aciklama="C# Delegate HaqqindaC# Delegate Haqqinda",EklenmeTarihi=DateTime.Now.AddDays(-10),IlkSeyfe=false,Onay=true,Icerik="C# Delegate HaqqindaC# Delegate Haqqinda",Resm="2.jpg",CategoryId=2},
                new Blog{Basliq="C# Delegate Haqqinda",Aciklama="C# Delegate HaqqindaC# Delegate Haqqinda",EklenmeTarihi=DateTime.Now.AddDays(-10),IlkSeyfe=true,Onay=false,Icerik="C# Delegate HaqqindaC# Delegate Haqqinda",Resm="3.jpg",CategoryId=3},
                new Blog{Basliq="C# Delegate Haqqinda",Aciklama="C# Delegate HaqqindaC# Delegate Haqqinda",EklenmeTarihi=DateTime.Now.AddDays(-15),IlkSeyfe=true,Onay=true,Icerik="C# Delegate HaqqindaC# Delegate Haqqinda",Resm="3.jpg",CategoryId=3},
                new Blog{Basliq="C# Delegate Haqqinda",Aciklama="C# Delegate HaqqindaC# Delegate Haqqinda",EklenmeTarihi=DateTime.Now.AddDays(-10),IlkSeyfe=true,Onay=true,Icerik="C# Delegate HaqqindaC# Delegate Haqqinda",Resm="3.jpg",CategoryId=3},
                new Blog{Basliq="C# Delegate Haqqinda",Aciklama="C# Delegate HaqqindaC# Delegate Haqqinda",EklenmeTarihi=DateTime.Now.AddDays(-10),IlkSeyfe=false,Onay=true,Icerik="C# Delegate HaqqindaC# Delegate Haqqinda",Resm="4.jpg",CategoryId=4},
                new Blog{Basliq="C# Delegate Haqqinda",Aciklama="C# Delegate HaqqindaC# Delegate Haqqinda",EklenmeTarihi=DateTime.Now.AddDays(-25),IlkSeyfe=true,Onay=false,Icerik="C# Delegate HaqqindaC# Delegate Haqqinda",Resm="4.jpg",CategoryId=4},
                new Blog{Basliq="C# Delegate Haqqinda",Aciklama="C# Delegate HaqqindaC# Delegate Haqqinda",EklenmeTarihi=DateTime.Now.AddDays(-10),IlkSeyfe=true,Onay=true,Icerik="C# Delegate HaqqindaC# Delegate Haqqinda",Resm="4.jpg",CategoryId=4},
            };
            foreach (var item in bloglar)
            {
                context.Bloglar.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}