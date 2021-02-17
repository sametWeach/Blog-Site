using MvcBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlog.Controllers
{
    public class KategoriController : Controller
    {
        Model1 db = new Model1();
        // GET: Kategori
        public ActionResult Index(int id)
        {
            
            return View(id);
        }
        public ActionResult makaleGetir(int id)
        {
            var data = db.makale.Where(x => x.KategoriID == id);
            return View("makaleGetir", data);
        }



    }
}