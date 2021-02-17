using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class YazarController : Controller
    {
        Model1 db = new Model1();
        // GET: Yazar
        public ActionResult Index(Guid id)
        {
            return View(id);
        }
        public ActionResult makaleGetir(Guid id)
        {
            var data = db.makale.Where(x => x.YazarID == id);
            return View("makaleGetir", data);
        }
    }
}