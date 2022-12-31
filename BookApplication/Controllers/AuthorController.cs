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
        MvcDbLibraryEntities2 db = new MvcDbLibraryEntities2();
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
            List<SelectListItem> values = (from i in db.TBLGENDER.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.GENDERNAME,
                                               Value = i.GENDERID.ToString()
                                           }).ToList();
            ViewBag.value = values;
            return View();
            
        }


        [HttpPost]
        public ActionResult NewAuthor(TBLAUTHOR p1)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("NewAuthor");
            //}

            try
            {
                var gnd = db.TBLGENDER.Where(m => m.GENDERID == p1.TBLGENDER.GENDERID).FirstOrDefault();
                p1.TBLGENDER = gnd;
                db.TBLAUTHOR.Add(p1);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                TempData["AlertMessage"] = " Existing author cannot be saved!";
                return RedirectToAction("Index");
            }
            
        }
    }
}