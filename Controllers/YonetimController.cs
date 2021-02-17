using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBlog.Models;

namespace MvcBlog.Controllers
{
    using Models;
    using MvcBlog.ayarlar;
   // [_securityFilter]

    public class YonetimController : Controller
    {
       

        Model1 db = new Model1();
        // GET: Yonetim
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult makaleYaz()
        {
            ViewBag.kategori = db.kategori.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult makaleYaz(makale makale,HttpPostedFileBase Resim2, string etiketler)
        {

            if (makale != null)
            {
                

                kullanici aktif = Session["Kullanici"] as kullanici;
                makale.YayinTarihi = DateTime.Now;
                makale.MakaleTipID = 1;
                makale.YazarID = aktif.Id;
                makale.KapakResimID = ResimKaydet(Resim2, HttpContext);
                db.makale.Add(makale);
                db.SaveChanges();

                string[] etikets = etiketler.Split(',');
                foreach (string etiket in etikets)
                {
                    etiket etk = db.etiket.FirstOrDefault(x => x.Ad.ToLower() == etiket.ToLower().Trim());
                    if (etk == null)
                    {
                        etk = new etiket();
                        etk.Ad = etiket;
                        db.etiket.Add(etk);
                        db.SaveChanges();
                                           
                    }
                        //etiket var
                        makale.etiket.Add(etk);
                        db.SaveChanges();                   
                }
            }            
            return RedirectToAction("MakaleListele");
        }


        public static int ResimKaydet(HttpPostedFileBase Resim,HttpContextBase ctx)
        {
            Model1 db = new Model1();
            

            kullanici k = (kullanici)ctx.Session["Kullanici"];

            int kucukWidth = Convert.ToInt32(ConfigurationManager.AppSettings["kw"]);
            int kucukHeight = Convert.ToInt32(ConfigurationManager.AppSettings["kh"]);
            int ortaWidth = Convert.ToInt32(ConfigurationManager.AppSettings["ow"]);
            int ortaHeight = Convert.ToInt32(ConfigurationManager.AppSettings["oh"]);
            int buyukWidth = Convert.ToInt32(ConfigurationManager.AppSettings["bw"]);
            int buyukHeight = Convert.ToInt32(ConfigurationManager.AppSettings["bh"]);

            string newName = Path.GetFileNameWithoutExtension(Resim.FileName)+"-" + Guid.NewGuid() + Path.GetExtension(Resim.FileName);

            Image orjRes = Image.FromStream(Resim.InputStream);
            Bitmap kucukRes = new Bitmap(orjRes, kucukWidth, kucukHeight);
            Bitmap ortaRes = new Bitmap(orjRes, ortaWidth, ortaHeight);
            Bitmap buyukRes = new Bitmap(orjRes, buyukWidth, buyukHeight);

            kucukRes.Save(ctx.Server.MapPath("~/Content/Resimler/Kucuk/" + newName));
            ortaRes.Save(ctx.Server.MapPath("~/Content/Resimler/Orta/" + newName));
            buyukRes.Save(ctx.Server.MapPath("~/Content/Resimler/Buyuk/" + newName));


            resim dbRes = new resim();
            dbRes.Ad = Resim.FileName;
            dbRes.BuyukResimYol = "/Content/Resimler/Buyuk/" + newName;
            dbRes.OrtaResimYol = "/Content/Resimler/Orta/" + newName;
            dbRes.KucukResimYol = "/Content/Resimler/Kucuk/" + newName;

            dbRes.EklenmeTarihi = DateTime.Now;
            dbRes.EkleyenID = k.Id;

            db.resim.Add(dbRes);
            db.SaveChanges();

            return dbRes.Id;

        }
        public ActionResult MakaleListele()
        {
            return View(db.makale.ToList());
        }



    }
}