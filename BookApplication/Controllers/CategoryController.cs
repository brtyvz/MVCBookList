using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookApplication.Models.Entitiy;
namespace BookApplication.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        MvcDbLibraryEntities2 db = new MvcDbLibraryEntities2();
        public ActionResult Index()
        {
            var values = db.TBLCATEGORIES.ToList();
            return View(values);
        }

        public ActionResult CategoryFilter(int id)
        {
            var values = db.TBLBOOKS.Where(x => x.BOOKCATEGORY == id).ToList();
            return View(values);
        }
    }
}