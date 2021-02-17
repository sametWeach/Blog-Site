using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlog.Controllers
{
    public class LoginController : Controller
    {
        Model1 db = new Model1();
        // GET: Login

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]                     
        public ActionResult Index(string kullaniciadi, string Sifre)
        {
          

            if (System.Web.Security.Membership.ValidateUser(kullaniciadi, Sifre))
            {
                FormsAuthentication.RedirectFromLoginPage(kullaniciadi, true);

                Guid id = (Guid)System.Web.Security.Membership.GetUser(kullaniciadi).ProviderUserKey;
                Session["Kullanici"] = db.kullanici.FirstOrDefault(x => x.Id == id);


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı veya şifre hatalı";
                return View();

            }



        }
    }
}