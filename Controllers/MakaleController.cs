using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class MakaleController : Controller
    {
        Model1 db = new Model1();
        // GET: Makale
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TariheGoreSirala(int yil,int ay)
        {
            ViewBag.yil=yil;
            ViewBag.ay=ay;
            return View();
        }
        public ActionResult makaleGetir(int yil=0,int ay=0)
        {
            var data = db.makale.Where(x => x.YayinTarihi.Year == yil && x.YayinTarihi.Month ==ay );
            return View("makaleGetir", data);
        }
        public ActionResult Detay(int id)
        {
            ViewBag.Kullanici = Session["Kullanici"];

           
            makale mk = db.makale.FirstOrDefault(x => x.Id == id);
            return View(mk);
        }

        [HttpPost]
        public ActionResult YorumYaz(Yorum yorum)
        {
            yorum.EklenmeTarihi = DateTime.Now;
            yorum.Baslik = "";
            yorum.Aktif = false;
            db.Yorum.Add(yorum);
            db.SaveChanges();
            return RedirectToAction("Detay", new { id = yorum.MakaleID });
        }

      

    }
}