using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMvcApp.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Basliq { get; set; }
        public string Aciklama { get; set; }
        public string Resm { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public bool Onay { get; set; }
        public bool IlkSeyfe { get; set; }
        public int CategoryId { get; set; }
    }
}