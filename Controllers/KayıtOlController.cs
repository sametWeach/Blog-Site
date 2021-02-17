using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlog.Controllers
{
    public class KayıtOlController : Controller
    {
        Model1 db = new Model1();
        // GET: KayıtOl
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(kullanici k,HttpPostedFileBase Resim)
        {

            MembershipUser user = Membership.CreateUser(k.Nick,k.Sifre,k.Mail);
            k.Id = (Guid)user.ProviderUserKey;
            Session["Kullanici"] = k;
            k.ResimID = YonetimController.ResimKaydet(Resim,HttpContext);
            k.KayitTarih = DateTime.Now;
            db.kullanici.Add(k);
            db.SaveChanges();

            FormsAuthentication.RedirectFromLoginPage(k.Nick, true);
            Session["Kullanici"] = k;

            return RedirectToAction("Index","Home");
        }
    }
}