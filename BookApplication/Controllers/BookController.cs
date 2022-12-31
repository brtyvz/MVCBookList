using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookApplication.Models.Entitiy;

namespace BookApplication.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        MvcDbLibraryEntities2 db = new MvcDbLibraryEntities2();
        public ActionResult Index(string p)
        {
            var values = from d in db.TBLBOOKS select d;
            if (!string.IsNullOrEmpty(p)) {
                values = values.Where(m => m.BOOKNAME.Contains(p));
            }
            //empty search
            return View(values.ToList());
            
            //var values = db.TBLBOOKS.ToList();
            //return View(values);
        }

        [HttpGet]
        public ActionResult NewBook()
        {
            List<SelectListItem> values = (from i in db.TBLCATEGORIES.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CATEGORYNAME,
                                               Value = i.CATEGORYID.ToString()
                                           }).ToList();
            ViewBag.value = values;
            return View();
        }


        [HttpPost]
        public ActionResult NewBook(TBLBOOKS p1,string name)
        {
            // check for existing data

            //var bookname = db.TBLBOOKS.Where(x => x.BOOKNAME == name).FirstOrDefault();
            //if (bookname != null)
            //{
            //    ViewBag.Message = "Exist";
            //    return View();
            //}
            //else
            //{
            //    return View("Index");
            //}

            try
            {
                var ctg = db.TBLCATEGORIES.Where(m => m.CATEGORYID == p1.TBLCATEGORIES.CATEGORYID).FirstOrDefault();
                p1.TBLCATEGORIES = ctg;
                db.TBLBOOKS.Add(p1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            catch(Exception ex) 
            {
                TempData["AlertMessage"] = " Existing book cannot be saved!";
                return RedirectToAction("Index");
            }
        }
    }
}