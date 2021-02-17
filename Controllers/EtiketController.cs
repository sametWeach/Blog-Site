using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class EtiketController : Controller
    {
        Model1 db = new Model1();
        // GET: Etiket
        public ActionResult Index(int id)
        {
            return View(id);
        }
        public ActionResult makaleGetir(int id)
        {
            var data = db.makale.Where(x => x.etiket.Any(me => me.Id == id));
            return View("makaleGetir", data);
        }

    }
}