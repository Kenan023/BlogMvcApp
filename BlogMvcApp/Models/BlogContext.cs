using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class BlogContext:DbContext
    {
        public BlogContext():base("blogDb")
        {
            Database.SetInitializer(new BlogInitializer()); //new BlogInitializer ise dusur burda 
        }
        public DbSet<Blog> Bloglar { get; set; }
        public DbSet<Category> Kategoriler { get; set; }
    }
}