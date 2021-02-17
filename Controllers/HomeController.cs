using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
   
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        // GET: Home
        public ActionResult Index()
        {
           

            return View();
        }
        public ActionResult kategoriGetir()
        {
            var kat = db.kategori.OrderByDescending(x => x.makale.Count).Take(5);
            return View(kat);

            //return View(db.kategori.ToList());
        }

        public ActionResult sonEklenenler()
        {
            ViewBag.Fresh = db.makale.OrderByDescending(x => x.YayinTarihi).Take(5);
            ViewBag.Populer = db.makale.OrderByDescending(x => x.Goruntulenme).Take(5);
            return View();
        }

        public ActionResult tagGetir()
        {
            var tag = db.etiket.OrderByDescending(x => x.makale.Count).Take(5);
            return View(tag);
        }
        public ActionResult makaleGetir()
        {
            var mk = db.makale.OrderByDescending(x => x.YayinTarihi).ToList();
            return View("makaleGetir",mk);

            //var makaleler = db.makale.ToList();
            //return View("makaleGetir",makaleler);
        }


    }
}