using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookApplication.Models.Entitiy;

namespace BookApplication.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        MvcDbLibraryEntities db = new MvcDbLibraryEntities();
        public ActionResult Index(string p)
        {
            var values = from d in db.TBLAUTHOR select d;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(m => m.AUTHORNAME.Contains(p));
            }
            //empty search
            return View(values.ToList());

            //var values = db.TBLAUTHOR.ToList();
            //return View(values);
        }

        [HttpGet]
        public ActionResult NewAuthor() {
            return View();
        }


        [HttpPost]
        public ActionResult NewAuthor(TBLAUTHOR p1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewAuthor");
            }

            db.TBLAUTHOR.Add(p1);
            db.SaveChanges();
            return View();
        }
    }
}